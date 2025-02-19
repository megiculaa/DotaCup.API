namespace DotaCup.API.Configuration;

public static class CorsConfiguration
{
    public static IServiceCollection CorsRegister(this IServiceCollection services)
    {
        services.AddCors();

        return services;
    }
    public static WebApplication CorsConfigure(this WebApplication app)
    {
        app.UseCors(x => x
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed(origin => true)
            .AllowCredentials());


        return app;
    }
}
