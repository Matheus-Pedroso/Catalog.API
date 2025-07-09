using Catalog.Domain.Account;
using Catalog.WebUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.WebUI.Controllers;

public class AccountController(IAuthenticate authentication) : Controller
{
    #region VIEWS
    [HttpGet]
    public IActionResult Login(string returnUrl = "")
        => View(new LoginViewModel { ReturnUrl = returnUrl });

    [HttpGet]
    public IActionResult Register()
        => View();
    #endregion

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model)
    {
        var result = await authentication.Authenticate(model.Email, model.Password);

        if (result)
        {
            if (string.IsNullOrEmpty(model.ReturnUrl))
            {
                return RedirectToAction("Index", "Home");
            }
            return Redirect(model.ReturnUrl);
        }
        else
        {
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View(model);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        var result = await authentication.Register(model.Email, model.Password);

        if (result)
            return RedirectToAction("/");
        else
        {
            ModelState.AddModelError(string.Empty, "Registration failed.");
            return View(model);
        }
    }

    public async Task<IActionResult> Logout()
    {
        await authentication.Logout();
        return Redirect("/Account/Login");
    }
}
