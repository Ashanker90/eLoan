using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eLoan.Data;
using eLoan.Models;
using Microsoft.AspNetCore.Http;

namespace eLoan.Controllers
{
    public class DecisionMakingController : Controller
    {
        private readonly eLoanContext _context;

        public DecisionMakingController(eLoanContext context)
        {
            _context = context;
        }

        private Boolean dec;
        private double loan_amount;
        private double interest_rate;
        private int tenure;
        private double monthly_payment;
        //const int app_id = 0;
        public const string app_id = "app_id";
        public const string profile_id = "profile_id";
        public const string loan_details_id = "loan_details_id";
        //public const string email = "email";

        public async Task<IActionResult> DecisionAsync(Application app)
        {

            DecisionMakingScript helper = new DecisionMakingScript(app, _context);

            //DecisionMakingScript(app, _context).Decision();
            dec = helper.Decision();
            if (dec == true) {

                loan_amount = helper.Loan_amount();
                interest_rate = helper.Interest_rate();
                tenure = helper.tenure_in_months();
                monthly_payment = helper.Monthly_payment();
                ViewData["loan"] = loan_amount;
                ViewData["interest_rate"] = interest_rate;
                ViewData["tenure"] = tenure;
                ViewData["monthly_payment"] = monthly_payment;

                HttpContext.Session.SetInt32(app_id, app.application_id);
                HttpContext.Session.SetInt32(profile_id, app.profile_id);

                ViewData["app_id"] = HttpContext.Session.GetInt32(app_id);

                var ld = new Loan_details();
                ld.balance = (float)loan_amount;
                ld.loan_amount = (float)loan_amount;
                ld.interest_rate = (float)interest_rate;
                ld.tenure = tenure;
                ld.loan_date = DateTime.Today;
                _context.Add(ld);

                await _context.SaveChangesAsync();

                HttpContext.Session.SetInt32(loan_details_id, ld.loan_details_id);

                ViewData["loan_details_id"] = HttpContext.Session.GetInt32(loan_details_id);

                //HttpContext.Session.SetString(email, );

                return View("~/Views/DecisionMaking/LoanApproved.cshtml");
            } else
            {
                return View("~/Views/DecisionMaking/LoanDisApproved.cshtml");
            }
        }

        //public IActionResult create_loan(Application app)
        //{ }
        //private object DecisionMakingScript(Application app, eLoanContext context)
        //{
        //    throw new NotImplementedException();
        //}
    }
}