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

        public const string customer_id = "customer_id";
        public const string logged_in = "logged_in";

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(Login incoming_login)
        {
            //public string email = login.email;
            var login_details = await _context.logins
               .FirstOrDefaultAsync(m => m.email == incoming_login.email);

            if (login_details == null)
            {
                return NotFound();
            }

            if (login_details.password != incoming_login.password)
            {
                return NotFound();
            }
            HttpContext.Session.SetInt32(customer_id, incoming_login.customer_id);
            HttpContext.Session.SetString(logged_in, "true");

            return RedirectToAction("Details", "Customer", new { id = login_details.customer_id });
        }
    }
}

