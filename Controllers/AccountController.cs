using InternForge.Models;
using Microsoft.AspNetCore.Mvc;

namespace InternForge.Controllers
{
    public class AccountController : Controller
    {
        // -----------------------------
        // GET: /Account/Register
        // -----------------------------
        [HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        // -----------------------------
        // POST: /Account/Register
        // -----------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // TODO: Save user later

            if (model.Role == "SME")
                return RedirectToAction("Dashboard", "Sme");

            return RedirectToAction("Dashboard", "Student");
        }


        // -----------------------------
        // GET: /Account/Login
        // -----------------------------
        [HttpGet]
        public IActionResult Login()
        {
            return View(new LoginViewModel());
        }

        // -----------------------------
        // POST: /Account/Login
        // -----------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // TODO: Validate user later

            if (model.Role == "SME")
                return RedirectToAction("Dashboard", "Sme");

            return RedirectToAction("Dashboard", "Student");
        }
    }
}
