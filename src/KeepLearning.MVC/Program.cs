using KeepLearning.Infrastructure.Extensions;
using KeepLearning.MVC.Middlewares;
using KeepLearning.MVC.HealthChecker;
using KeepLearning.Application.Common.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddInfrastructure();
builder.Services.AddApplication();

builder.Services.AddHealthChecks()
    .AddCheck<EnvironmentHealthChecker>("EnvironmentHealthChecker");

builder.Services.AddScoped<ErrorHandlingMiddleware>();

var app = builder.Build();

app.Services.SeedData();

app.MapHealthChecks("healthz");

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

app.UseAuthorization();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
