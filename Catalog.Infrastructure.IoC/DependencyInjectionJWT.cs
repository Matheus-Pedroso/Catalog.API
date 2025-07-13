using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Catalog.Infrastructure.IoC
{
    public static class DependencyInjectionJWT
    {
        public static IServiceCollection AddInfrastructureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            // Add JWT authentication services
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer( options =>
            {
               options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
               {
                   ValidateIssuer = true,
                   ValidateAudience = true,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,
                   ValidIssuer = configuration["Jwt:Issuer"],
                   ValidAudience = configuration["Jwt:Audience"],
                   IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration["Jwt:Key"])),
                   ClockSkew = TimeSpan.Zero
               };
            });

            // Add other infrastructure services
            return services;
        }
    }
}
