using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NotifyX.Data;
using NotifyX.Models;

var builder = WebApplication.CreateBuilder(args);

// Adicionando serviços ao contêiner **antes** de chamar builder.Build()
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 36))));

builder.Services.AddIdentity<AdminUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

var app = builder.Build();

// Configuração do pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseExceptionHandler("/Home/Error");
app.UseStatusCodePagesWithRedirects("/Home/Error?code={0}");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
