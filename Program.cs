using System.Security.Claims;
using KusinaKanto.Auth;
using KusinaKanto.Components;
using KusinaKanto.Services;
using KusinaKanto.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using KusinaKanto.Data;

var builder = WebApplication.CreateBuilder(args);

#region Blazor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddCascadingAuthenticationState();
#endregion

#region Authentication & Authorization
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login";
        options.AccessDeniedPath = "/login";
        options.ExpireTimeSpan = TimeSpan.FromHours(8);
    });

builder.Services.AddAuthorization();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IPasswordHasher<Staff>, PasswordHasher<Staff>>();
#endregion

#region Database
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Data Source=KusinaKanto.db";

builder.Services.AddDbContext<KusinaKantoDbContext>(options =>
    options.UseSqlite(connectionString));
#endregion

#region Application Services
builder.Services.AddScoped<IMenuService, EfMenuService>();
builder.Services.AddScoped<IOrderService, EfOrderService>();
builder.Services.AddScoped<IMenuAdminService, EfMenuAdminService>();
builder.Services.AddScoped<IStaffService, EfStaffService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<CartState>();
#endregion

var app = builder.Build();

#region Database Seed
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<KusinaKantoDbContext>();

    await DbInitializer.SeedAsync(db);
}
#endregion

#region Middleware Pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStaticFiles();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();
#endregion

#region Razor Components
app.MapStaticAssets();
app.MapAuthEndpoints();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();
#endregion

app.Run();