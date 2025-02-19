using DotaCup.API.Data;
using DotaCup.API.Models.Entities;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace DotaCup.API.Configuration;

public static class IdentityConfiguration
{
    public static IServiceCollection IdentityRegister(this IServiceCollection services, IConfiguration config)
    {
        services
            .AddIdentityCore<ApplicationUser>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
            .AddEntityFrameworkStores<ApplicationContext>();

            services.AddAuthentication()
            .AddGoogle(options =>
            {
                options.ClientId = config["Authentication:Google:ClientId"];
                options.ClientSecret = config["Authentication:Google:ClientSecret"];
                options.CallbackPath = config["Authentication:Google:CallbackPath"];
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(config["Jwt:Key"])
                    )
                };
            });

        return services;
    }
}