using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using webdersi.Models.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
           options.UseSqlServer("Server=DESKTOP-KCT444U\\SQLEXPRESS;Database=blog;Trusted_Connection=True;TrustServerCertificate=True"));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
