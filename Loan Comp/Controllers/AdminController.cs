using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Loan_Comp.Models;

namespace Loan_Comp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            var context = new ApplicationDbContext();
            var company = context.Companies.ToList();
            var infos = context.Info.ToList();

            var averageAmount = GetAverageAmount(infos);
            var highestDuration = GetHighestDuration(infos);

            Session["averageAmount"] = String.Format("{0:C}", averageAmount);
            Session["highestDuration"] = highestDuration;

            return View(company);
        }

        public double GetAverageAmount(List<Info> infos)
        {
            double amount = 0;

            foreach (var info in infos)
            {
                amount = amount + info.Amount;
            }

            if (infos.Count == 0)
            {
                var averageAmount = 0;
                return averageAmount;
            }
            else
            {
                var averageAmount = amount / infos.Count;
                return averageAmount;
            }


        }

        public double GetHighestDuration(List<Info> infos)
        {
            var durations = new List<double>();
            foreach (var info in infos)
            {
                durations.Add(info.Duration);
            }

            if (durations.Count != 0)
            {
                var highestDuration = durations.GroupBy(i => i).OrderByDescending(grp => grp.Count())
                    .Select(grp => grp.Key).First();
                return highestDuration;
            }
            else
            {
                var highestDuration = 0;
                return highestDuration;
            }

        }
    }
}