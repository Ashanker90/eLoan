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
    public class LoginController : Controller
    {
        private readonly eLoanContext _context;

        public LoginController(eLoanContext context)
        {
            _context = context;
        }

    
        // GET: Login/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("email,password,customer_id")] Login login)
        {
            if (ModelState.IsValid)
            {
                login.customer_id = (int)HttpContext.Session.GetInt32("customer_id");
                _context.Add(login);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["customer_id"] = new SelectList(_context.customers, "customer_id", "customer_id", login.customer_id);
            return View(login);
        }

        // GET: Login/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var login = await _context.logins.FindAsync(id);
            if (login == null)
            {
                return NotFound();
            }
            ViewData["customer_id"] = new SelectList(_context.customers, "customer_id", "customer_id", login.customer_id);
            return View(login);
        }

        // POST: Login/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("email,password,customer_id")] Login login)
        {
            if (id != login.email)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(login);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoginExists(login.email))
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
            ViewData["customer_id"] = new SelectList(_context.customers, "customer_id", "customer_id", login.customer_id);
            return View(login);
        }

        // GET: Login/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var login = await _context.logins
                .Include(l => l.Customer)
                .FirstOrDefaultAsync(m => m.email == id);
            if (login == null)
            {
                return NotFound();
            }

            return View(login);
        }

        // POST: Login/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var login = await _context.logins.FindAsync(id);
            _context.logins.Remove(login);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoginExists(string id)
        {
            return _context.logins.Any(e => e.email == id);
        }
    }
}
