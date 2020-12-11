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
    public class CustomerController : Controller
    {
        private readonly eLoanContext _context;

        public CustomerController(eLoanContext context)
        {
            _context = context;
        }

        // GET: Customer
        public async Task<IActionResult> Index()
        {
            var eLoanContext = _context.customers.Include(c => c.Application).Include(c => c.Bank_details).Include(c => c.Loan_details).Include(c => c.Profile);
            return View(await eLoanContext.ToListAsync());
        }

        // GET: Customer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.customers
                .Include(c => c.Application)
                .Include(c => c.Bank_details)
                .Include(c => c.Loan_details)
                .Include(c => c.Profile)
                .FirstOrDefaultAsync(m => m.customer_id == id);
            
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customer/Create
        public IActionResult Create()
        {
            ViewData["application_id"] = new SelectList(_context.applications, "application_id", "application_id");
            ViewData["bank_details_id"] = new SelectList(_context.bank_details, "bank_details_id", "bank_details_id");
            ViewData["loan_details_id"] = new SelectList(_context.loan_details, "loan_details_id", "loan_details_id");
            ViewData["profile_id"] = new SelectList(_context.profiles, "profile_id", "profile_id");
            return View();
        }

        // POST: Customer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("customer_id,profile_id,application_id,loan_details_id,bank_details_id")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["application_id"] = new SelectList(_context.applications, "application_id", "application_id", customer.application_id);
            ViewData["bank_details_id"] = new SelectList(_context.bank_details, "bank_details_id", "bank_details_id", customer.bank_details_id);
            ViewData["loan_details_id"] = new SelectList(_context.loan_details, "loan_details_id", "loan_details_id", customer.loan_details_id);
            ViewData["profile_id"] = new SelectList(_context.profiles, "profile_id", "profile_id", customer.profile_id);
            return View(customer);
        }

        // GET: Customer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            ViewData["application_id"] = new SelectList(_context.applications, "application_id", "application_id", customer.application_id);
            ViewData["bank_details_id"] = new SelectList(_context.bank_details, "bank_details_id", "bank_details_id", customer.bank_details_id);
            ViewData["loan_details_id"] = new SelectList(_context.loan_details, "loan_details_id", "loan_details_id", customer.loan_details_id);
            ViewData["profile_id"] = new SelectList(_context.profiles, "profile_id", "profile_id", customer.profile_id);
            return View(customer);
        }

        // POST: Customer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("customer_id,profile_id,application_id,loan_details_id,bank_details_id")] Customer customer)
        {
            if (id != customer.customer_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.customer_id))
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
            ViewData["application_id"] = new SelectList(_context.applications, "application_id", "application_id", customer.application_id);
            ViewData["bank_details_id"] = new SelectList(_context.bank_details, "bank_details_id", "bank_details_id", customer.bank_details_id);
            ViewData["loan_details_id"] = new SelectList(_context.loan_details, "loan_details_id", "loan_details_id", customer.loan_details_id);
            ViewData["profile_id"] = new SelectList(_context.profiles, "profile_id", "profile_id", customer.profile_id);
            return View(customer);
        }

        // GET: Customer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.customers
                .Include(c => c.Application)
                .Include(c => c.Bank_details)
                .Include(c => c.Loan_details)
                .Include(c => c.Profile)
                .FirstOrDefaultAsync(m => m.customer_id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.customers.FindAsync(id);
            _context.customers.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.customers.Any(e => e.customer_id == id);
        }
    }
}
