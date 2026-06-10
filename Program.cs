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

// Blazor Server (interactive Razor components).
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Authentication & authorization — cookie-based admin login.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/login";
        options.AccessDeniedPath = "/login";
        options.ExpireTimeSpan = TimeSpan.FromHours(8);
    });
builder.Services.AddAuthorization();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<AuthenticationStateProvider, HttpContextAuthStateProvider>();
builder.Services.AddSingleton<IPasswordHasher<Staff>, PasswordHasher<Staff>>();

// Data layer — EF Core + SQLite. The UI depends only on IMenuService / IOrderService.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Data Source=KusinaKanto.db";
builder.Services.AddDbContext<KusinaKantoDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddScoped<IMenuService, EfMenuService>();
builder.Services.AddScoped<IOrderService, EfOrderService>();

// Admin-side CRUD services.
builder.Services.AddScoped<IMenuAdminService, EfMenuAdminService>();
builder.Services.AddScoped<IStaffService, EfStaffService>();

// Per-session cart.
builder.Services.AddScoped<CartState>();

var app = builder.Build();
// Seed the database with initial menu data if it's empty.
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider
        .GetRequiredService<KusinaKantoDbContext>();

    await DbInitializer.SeedAsync(db);
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseAntiforgery();

// --- Admin auth endpoints (plain form posts, so they run outside the Blazor circuit) ---
app.MapPost("/auth/login", async (
    HttpContext ctx,
    IStaffService staff,
    IPasswordHasher<Staff> hasher) =>
{
    var form = await ctx.Request.ReadFormAsync();
    var email = form["email"].ToString().Trim();
    var password = form["password"].ToString();
    var returnUrl = form["returnUrl"].ToString();
    if (string.IsNullOrWhiteSpace(returnUrl) || !returnUrl.StartsWith('/')) returnUrl = "/admin";

    var member = await staff.GetByEmailAsync(email);
    var ok = member is { Role: StaffRole.Admin, IsActive: true }
             && !string.IsNullOrEmpty(member.PasswordHash)
             && hasher.VerifyHashedPassword(member, member.PasswordHash, password)
                 != PasswordVerificationResult.Failed;

    if (!ok)
        return Results.Redirect($"/login?error=true&returnUrl={Uri.EscapeDataString(returnUrl)}");

    var claims = new List<Claim>
    {
        new(ClaimTypes.NameIdentifier, member!.Id),
        new(ClaimTypes.Name, member.Name),
        new(ClaimTypes.Email, member.Email),
        new(ClaimTypes.Role, member.Role.ToString())
    };
    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
    await ctx.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
    return Results.Redirect(returnUrl);
}).DisableAntiforgery();

app.MapPost("/auth/logout", async (HttpContext ctx) =>
{
    await ctx.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
    return Results.Redirect("/login");
}).DisableAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
