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
    public class ProfileController : Controller
    {
        private readonly eLoanContext _context;

        public ProfileController(eLoanContext context)
        {
            _context = context;
        }

        public const string email = "email";

        // GET: Profile/Create
        public IActionResult Create(string address_id)
        {
            return View();
        }

        // POST: Profile/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("profile_id,first_name,last_name,email,birthdate,phone_number,address_id")] Profile profile)
        {
            if (ModelState.IsValid)
            {
                _context.Add(profile);
                await _context.SaveChangesAsync();

                HttpContext.Session.SetString(email, profile.email);
                return RedirectToAction("Create", "Application", new { profile_id = profile.profile_id });
            }
            // Incase an error occurs
            return View("Create");
        }
        // TODO Currently address_id is visible in view. Change that.
    }
}
