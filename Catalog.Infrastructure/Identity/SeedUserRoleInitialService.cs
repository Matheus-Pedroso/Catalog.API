using Catalog.Domain.Account;
using Microsoft.AspNetCore.Identity;

namespace Catalog.Infrastructure.Identity;

public class SeedUserRoleInitialService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager) : ISeedUserRoleInitial
{
    public void SeedUsers()
    {
        // Add user 
        if (userManager.FindByEmailAsync("usuario@localhost").Result == null)
        {
            ApplicationUser user = new ApplicationUser();
            user.UserName = "usuario@localhost";
            user.Email = "usuario@localhost";
            user.NormalizedUserName = "USUARIO@LOCALHOST";
            user.NormalizedEmail = "USUARIO@LOCALHOST";
            user.EmailConfirmed = true;
            user.LockoutEnabled = false;
            user.SecurityStamp = Guid.NewGuid().ToString();

            IdentityResult result = userManager.CreateAsync(user, "Numsey#2025").Result;

            if (result.Succeeded)
            {
                userManager.AddToRoleAsync(user, "User").Wait();
            }
        }

        // Add admin
        if (userManager.FindByEmailAsync("admin@localhost").Result == null)
        {
            ApplicationUser user = new ApplicationUser();
            user.UserName = "admin@localhost";
            user.Email = "admin@localhost";
            user.NormalizedUserName = "ADMIN@LOCALHOST";
            user.NormalizedEmail = "ADMIN@LOCALHOST";
            user.EmailConfirmed = true;
            user.LockoutEnabled = false;
            user.SecurityStamp = Guid.NewGuid().ToString();

            IdentityResult result = userManager.CreateAsync(user, "Numsey#2025").Result;

            if (result.Succeeded)
            {
                userManager.AddToRoleAsync(user, "Admin").Wait();
            }
        }
    }
    public void SeedRoles()
    {
        // Add user role
        if (!roleManager.RoleExistsAsync("User").Result)
        {
            IdentityRole role = new IdentityRole();
            role.Name = "User";
            role.NormalizedName = "USER";
            IdentityResult roleResult = roleManager.CreateAsync(role).Result;
        }

        // Add admin role
        if (!roleManager.RoleExistsAsync("Admin").Result)
        {
            IdentityRole role = new IdentityRole();
            role.Name = "Admin";
            role.NormalizedName = "ADMIN";
            IdentityResult roleResult = roleManager.CreateAsync(role).Result;
        }
    }
}
