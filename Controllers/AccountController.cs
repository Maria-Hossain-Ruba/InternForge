using InternForge.Models;
using InternForge.Repositories.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static InternForge.Models.Auth.IdentityModel;

namespace InternForge.Controllers;

public class AccountController(SignInManager<User> signInManager,
        IAuthService authService) : Controller
{
    [HttpGet]
    public IActionResult Register()
    {
        return View(new RegisterViewModel());
    }
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
    [HttpGet]
    public IActionResult Login()
    {
        return View(new LoginViewModel());
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        try
        {
            if (!ModelState.IsValid)
                return View(model);

            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            if (result.Succeeded)
                return LocalRedirect("/dashboard");
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View(model);
        }
        catch (Exception ex)
        {

            throw;
        }
       
    }
}
