using System.Threading.Tasks;
using Catalog.Domain.Account;
using Catalog.Infrastructure.IoC;

namespace Catalog.WebUI;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddInfrastructure(builder.Configuration);
        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        // Creating a default users and roles
        SeedDataAsync(app);

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }

    private static void SeedDataAsync(WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var seedServices = scope.ServiceProvider.GetRequiredService<ISeedUserRoleInitial>();
            seedServices.SeedRoles();
            seedServices.SeedUsers();
        }
    }
}
