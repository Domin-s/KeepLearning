using Infrastructure.Extensions;
using MVC.Middlewares;
using MVC.HealthChecker;
using Application.Common.Extensions;

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

app.UseMiddleware<ErrorHandlingMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();