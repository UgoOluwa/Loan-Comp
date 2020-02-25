using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Loan_Comp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Paystack.Net.SDK.Transactions;


namespace Loan_Comp.Controllers
{
    public class CompanyController : Controller
    {

        public static List<CompanyViewModel> CheckAmount(List<CompanyViewModel> companies, CompanyViewModel companyInput)
        {
            var viableCompanies = new List<CompanyViewModel>();
            foreach (var company in companies)
            {
                if (company.MinimumAmount <= companyInput.MinimumAmount && company.MaximumAmount >= companyInput.MinimumAmount && company.LoanPurpose == companyInput.LoanPurpose)
                {
                    if (company.Duration == companyInput.Duration)
                    {
                        viableCompanies.Add(company);
                    }

                }
            }

            return viableCompanies;
        }
        // GET: Company
        public ActionResult Index()
        {
            var Duration = new List<double>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            return View(Duration);
        }

        [Authorize]
        public ActionResult CompanyDetails(CompanyViewModel company)
        {

            var interest = (company.Rate * company.MinimumAmount) / 100;
            company.MinimumAmount = interest + company.MinimumAmount;
            company.MaximumAmount = company.MinimumAmount / company.Duration;
            return View(company);
        }

        [HttpPost]
        public ActionResult Company(CompanyViewModel company)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "All the fields are required";
                return View("Index");
            }

            using (var context = new ApplicationDbContext())
            {
                var companies = context.Companies.ToList();
                var companiesRequired = CheckAmount(companies, company);
                ViewBag.Amount = company.MinimumAmount;
                return View(companiesRequired);
            }

        }

        #region Add Company

        [Authorize(Roles = "Admin")]
        public ActionResult AddCompany(object returnurl)
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult AddCompany(CompanyViewModel company)
        {
            try
            {
                using (var context = new ApplicationDbContext())
                {
                    context.Companies.Add(company);
                    context.SaveChanges();
                }

                ViewBag.ErrorMessage = "Company was added Successfully";
            }
            catch (Exception e)
            {
                ViewBag.ErrorMessage = e.Message;
            }


            return View();
        }

        #endregion

        public ActionResult CompanyList()
        {
            var context = new ApplicationDbContext();

            var Companies = context.Companies;
            return View(Companies);


        }

        public ActionResult Clicks(CompanyViewModel companyViewModel)
        {
            using (var context = new ApplicationDbContext())
            {
                var currentUser = System.Web.HttpContext.Current.GetOwinContext()
                    .GetUserManager<ApplicationUserManager>()
                    .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

                var clicks = context.Clicks
                    .Where(p => p.UserId == currentUser.Id && p.CompanyId == companyViewModel.Id).ToList();

                Session["CompanyToGo"] = companyViewModel.Link;

                var company = context.Companies.Find(companyViewModel.Id);

                //'Validation failed for one or more entities. See 'EntityValidationErrors' property for more details.'

                if (clicks.Count == 0)
                {
                    var click = new Clicks();
                    click.UserId = currentUser.Id;
                    click.CompanyId = companyViewModel.Id;

                    context.Clicks.Add(click);
                    company.Count = company.Count + 1;
                    company.UniqueCount = company.UniqueCount + 1;
                    context.SaveChanges();
                }
                else
                {
                    company.Count = company.Count + 1;
                    context.SaveChanges();
                }
            }


            return RedirectToAction("Payments", companyViewModel);

        }

        public ActionResult Payments(CompanyViewModel companyViewModel)
        {
            var context = new ApplicationDbContext();
            var currentUser = System.Web.HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>()
                .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());

            var payments = context.Payments.Find(currentUser.Id);

            if (payments != null && payments.StartDate < DateTime.Now && payments.EndDate > DateTime.Now)
            {
                return Redirect(companyViewModel.Link);
            }
            else
            {
                //go to payment
                return RedirectToAction("InitializePayment", currentUser);

            }
        }
        public async Task<ActionResult> InitializePayment(User model)
        {
            string secretKey = ConfigurationManager.AppSettings["PaystackSecret"];
            var paystackTransactionAPI = new PaystackTransaction(secretKey);
            var response = await paystackTransactionAPI.InitializeTransaction(model.Email, 5000000, model.Name, model.UserName, $"{Session["CompanyToGo"]}");
            //Note that callback URL is optional

            using (var context = new ApplicationDbContext())
            {
                var payment = new Payment
                {
                    UserId = model.Id,
                    StartDate = DateTime.Now
                };
                payment.EndDate = payment.StartDate.AddMonths(2);

                context.Payments.Add(payment);
                context.SaveChanges();
            }

            return Redirect(response.data.authorization_url);

        }



    }
}