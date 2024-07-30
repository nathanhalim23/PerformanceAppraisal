using EmployeeAppraisalWeb.Configurations;
using Microsoft.AspNetCore.Authentication.Cookies;
using static EmployeeAppraisalDataAccess.Dependencies;


var builder = WebApplication.CreateBuilder(args);

IServiceCollection services = builder.Services;
IConfiguration configuration = builder.Configuration;
services.AddControllersWithViews();

ConfigureService(configuration, services);
services.AddBusinessServices();

services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme
)
.AddCookie(options =>
{
    options.Cookie.Name = "AuthenticationCookie";
    options.LoginPath = "/LoginFail";
    options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    options.AccessDeniedPath = "/AccessDenied";
});

services.AddAuthentication();
services.AddAuthorization();

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

app.UseAuthorization();
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=LoginPage}");

app.Run();


