using DotaCup.API.Data;
using Microsoft.EntityFrameworkCore;

namespace DotaCup.API.Configuration;

public static class DatabaseConfiguration
{
    public static IServiceCollection DataBaseRegister(this IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<ApplicationContext>(options =>
            options.UseNpgsql(config["ConnectionStrings:DefaultConnection"]));

        return services;
    }
}