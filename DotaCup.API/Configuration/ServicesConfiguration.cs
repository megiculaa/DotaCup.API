using DotaCup.API.Data.Interfaces;
using DotaCup.API.Data.Repository;
using DotaCup.API.Models.Config;
using DotaCup.API.Profiles;
using DotaCup.API.Services;

namespace DotaCup.API.Configuration;

public static class ServicesConfiguration
{
    public static IServiceCollection ServicesRegister(this IServiceCollection services, IConfiguration config)
    {
        services.AddAntiforgery(o => o.HeaderName = "X-XSRF-TOKEN");

        services.AddScoped<ITournamentService, TournamentService>();
        services.AddScoped<IClipService, ClipService>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IJwtService, JwtService>();

        services.AddAutoMapper(typeof(MappingProfile));

        services.AddScoped<IGoogleAuthService, GoogleAuthService>();
        services.Configure<GoogleAuthConfig>(config.GetSection("Authentication:Google"));

        return services;
    }
}
