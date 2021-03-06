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
    public class AddressController : Controller
    {
        private readonly eLoanContext _context;

        public AddressController(eLoanContext context)
        {
            _context = context;
        }

        // GET: Address/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Address/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("address_id,street,city,state,country,zip_code")] Address address)
        {
            if (ModelState.IsValid)
            {
                _context.Add(address);
                await _context.SaveChangesAsync();
                // Pass address_id since its a foriegn key
                return RedirectToAction("Create", "Profile", new { address_id = address.address_id });
            }
            // Incase an error occurs
            return View("Create");
        }
    }
}
