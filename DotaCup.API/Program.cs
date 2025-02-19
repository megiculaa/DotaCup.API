using DotaCup.API.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

builder.Services.CorsRegister();
builder.Services.DataBaseRegister(builder.Configuration);
builder.Services.ServicesRegister(builder.Configuration);
builder.Services.IdentityRegister(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.SwaggerRegister();

var app = builder.Build();

app.SwaggereConfigure();
app.CorsConfigure();
app.UseHttpsRedirection();
app.UseAuthorization();
app.UseAuthentication();
app.MapControllers();
app.Run();
