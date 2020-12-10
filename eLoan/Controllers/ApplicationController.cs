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
    public class ApplicationController : Controller
    {
        private readonly eLoanContext _context;

        public ApplicationController(eLoanContext context)
        {
            _context = context;
        }

        // GET: Application/Create
        public IActionResult Create(string profile_id)
        {
            //ViewData["profile_id"] = new SelectList(_context.profiles, "profile_id", "profile_id");
            return View();
        }

        // POST: Application/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("application_id,last4ssn,loan_state,employee_name,monthly_salary,rent_mortgage_expense,additional_expense,amount_requested,tenure_in_months,application_date,profile_id")] Application application)
        {
            application.loan_state = "in_progress";

            if (ModelState.IsValid)
            {
                _context.Add(application);
                await _context.SaveChangesAsync();
                return RedirectToAction("Decision", "DecisionMaking", application);
            }
            ViewData["profile_id"] = new SelectList(_context.profiles, "profile_id", "profile_id", application.profile_id);
            return View(application);
        }
    }
}
