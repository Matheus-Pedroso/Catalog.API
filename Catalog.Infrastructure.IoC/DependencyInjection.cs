using System.Reflection;
using Catalog.Application;
using Catalog.Application.Interfaces;
using Catalog.Application.Services;
using Catalog.Domain.Account;
using Catalog.Domain.Interfaces;
using Catalog.Domain.Interfacesl;
using Catalog.Infrastructure.Context;
using Catalog.Infrastructure.Identity;
using Catalog.Infrastructure.Repositories;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Infrastructure.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

        // Configuration Cookies
        services.ConfigureApplicationCookie(options => options.AccessDeniedPath = "/Account/Login");

        // Configure Identity
        services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>() // Use the ApplicationDbContext for Identity persistence in the database
            .AddDefaultTokenProviders(); // Add default token providers for password reset, email confirmation, etc.

        // Configuration for Mapster
        MapsterConfig.RegisterMappings();
        services.AddSingleton(TypeAdapterConfig.GlobalSettings);
        services.AddScoped<IMapper, ServiceMapper>();

        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IAuthenticate, AuthenticateServices>();
        services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitialService>();

        // MediatR
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly((Assembly.Load("Catalog.Application"))));

        return services;
    }
}
