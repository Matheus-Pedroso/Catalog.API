using Catalog.Domain.Account;
using Microsoft.AspNetCore.Identity;

namespace Catalog.Infrastructure.Identity;

public class AuthenticateServices(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager) : IAuthenticate
{
    public async Task<bool> Authenticate(string email, string password)
    {
        var result = await signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);

        return result.Succeeded;

    }
    public async Task<bool> Register(string email, string password)
    {
        var applicationUser = new ApplicationUser
        {
            UserName = email,
            Email = email
        };

        var result = await userManager.CreateAsync(applicationUser, password);

        if (result.Succeeded) 
            await signInManager.SignInAsync(applicationUser, isPersistent: false);

        return result.Succeeded;
    }
    public async Task Logout()
    {
        await signInManager.SignOutAsync();
    }
}
