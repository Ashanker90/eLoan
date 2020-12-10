using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eLoan.Data;
using eLoan.Models;

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

        public IActionResult Decision(Application app)
        {

            DecisionMakingScript helper = new DecisionMakingScript(app, _context);

            //DecisionMakingScript(app, _context).Decision();
            dec = helper.Decision();
            if (dec == true) {

                loan_amount = helper.Loan_amount();
                interest_rate = helper.Interest_rate();
                tenure = helper.tenure_in_months();
                ViewData["loan"] = loan_amount;
                ViewData["interest_rate"] = interest_rate;
                ViewData["tenure"] = tenure;
                return View("~/Views/DecisionMaking/LoanApproved.cshtml");
            } else
            {
                return View("~/Views/DecisionMaking/LoanDisApproved.cshtml");
            }
        }

        //private object DecisionMakingScript(Application app, eLoanContext context)
        //{
        //    throw new NotImplementedException();
        //}
    }
}