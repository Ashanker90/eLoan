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
    public class BankDetailsController : Controller
    {
        private readonly eLoanContext _context;
                public const string app_id = "app_id";

        public BankDetailsController(eLoanContext context)
        {
            _context = context;
        }

        public const string customer_id = "customer_id";
        // GET: BankDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.bank_details.ToListAsync());
        }

        // GET: BankDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bank_details = await _context.bank_details
                .FirstOrDefaultAsync(m => m.bank_details_id == id);
            if (bank_details == null)
            {
                return NotFound();
            }

            return View(bank_details);
        }

        // GET: BankDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BankDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("bank_details_id,bank_name,routing_number,account_number")] Bank_details bank_details)
        {
           
            if (ModelState.IsValid)
            {
                _context.Add(bank_details);
                await _context.SaveChangesAsync();

                var c = new Customer();
                c.application_id = (int)HttpContext.Session.GetInt32("app_id");
                c.profile_id = (int)HttpContext.Session.GetInt32("profile_id"); ;
                c.loan_details_id = (int)HttpContext.Session.GetInt32("loan_details_id");
                c.bank_details_id = bank_details.bank_details_id;

                _context.Add(c);
                await _context.SaveChangesAsync();

                HttpContext.Session.SetInt32(customer_id, c.customer_id);
                return RedirectToAction("Create", "Login");
            }
            return View(bank_details);
        }

        // GET: BankDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bank_details = await _context.bank_details.FindAsync(id);
            if (bank_details == null)
            {
                return NotFound();
            }
            return View(bank_details);
        }

        // POST: BankDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("bank_details_id,bank_name,routing_number,account_number")] Bank_details bank_details)
        {
            if (id != bank_details.bank_details_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bank_details);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Bank_detailsExists(bank_details.bank_details_id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bank_details);
        }

        // GET: BankDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bank_details = await _context.bank_details
                .FirstOrDefaultAsync(m => m.bank_details_id == id);
            if (bank_details == null)
            {
                return NotFound();
            }

            return View(bank_details);
        }

        // POST: BankDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bank_details = await _context.bank_details.FindAsync(id);
            _context.bank_details.Remove(bank_details);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Bank_detailsExists(int id)
        {
            return _context.bank_details.Any(e => e.bank_details_id == id);
        }
    }
}
