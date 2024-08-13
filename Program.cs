using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Paradise.Data;
using Paradise.Models;
using Paradise.Models.FormModels;
using Paradise.Services;
using Paradise.Utilities;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
//builder.Services.AddIdentity<SuperUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddScoped<IFormRepository<Medicare>,FormRepository<Medicare>>();

builder.Services.AddIdentity<SuperUser, IdentityRole>(options =>
{

    options.SignIn.RequireConfirmedAccount = false;
    options.Lockout.MaxFailedAccessAttempts = 5; // Lockout after 5 failed attempts
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15); // Lockout period
}).AddEntityFrameworkStores<AppDbContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login"; // Redirect to this path if not authenticated
    options.AccessDeniedPath = "/Account/AccessDenied"; // Redirect here if not authorized
    options.ExpireTimeSpan = TimeSpan.FromMinutes(30); // Cookie expiration time
    options.SlidingExpiration = true;
});


builder.Services.Configure<IdentityOptions>(options =>
{
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;
});
var app = builder.Build();
// Seeding Admin User
await Utilities.SeedAdminUserAsync(app);

if (!app.Environment.IsDevelopment())
{
    //app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/Home/NotFound");
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// Route for Admin Area
app.MapControllerRoute(
    name: "admin",
    pattern: "{area:exists}/{controller=Admin}/{action=Index}/{id?}");

// Default Route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
