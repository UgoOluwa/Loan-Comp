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


            return View(company);
        }
    }
}