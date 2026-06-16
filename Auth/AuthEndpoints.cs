using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using KusinaKanto.Models;
using KusinaKanto.Services;

namespace KusinaKanto.Auth;

public static class AuthEndpoints
{
   public static void MapAuthEndpoints(this IEndpointRouteBuilder app)
{
    app.MapPost("/auth/login", async (
        HttpContext ctx,
        IStaffService staff,
        IPasswordHasher<Staff> hasher) =>
        await Login(ctx, staff, hasher));

    app.MapPost("/auth/logout", async (HttpContext ctx) =>
        await Logout(ctx));
}

    private static async Task<IResult> Login(
        HttpContext ctx,
        IStaffService staff,
        IPasswordHasher<Staff> hasher)
    {
        var form = await ctx.Request.ReadFormAsync();
        var email = form["email"].ToString().Trim().ToLower();
        var password = form["password"].ToString();

        var member = await staff.GetByEmailAsync(email);

        // FIX: full validation
        if (member is null ||
            !member.IsActive ||
            string.IsNullOrEmpty(member.PasswordHash))
        {
            return Results.Redirect("/login?error=true");
        }

        var verifyResult = hasher.VerifyHashedPassword(
            member,
            member.PasswordHash,
            password);

        if (verifyResult == PasswordVerificationResult.Failed)
        {
            return Results.Redirect("/login?error=true");
        }

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, member.Id),
            new(ClaimTypes.Name, member.Name),
            new(ClaimTypes.Email, member.Email),
            new(ClaimTypes.Role, member.Role.ToString())
        };

        var identity = new ClaimsIdentity(
            claims,
            CookieAuthenticationDefaults.AuthenticationScheme);

        await ctx.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            new ClaimsPrincipal(identity));

        // FIX: correct redirect method
        return Results.Redirect(RoleRedirects.GetHomePage(member.Role));
    }

    private static async Task<IResult> Logout(HttpContext ctx)
    {
        await ctx.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        return Results.Redirect("/login");
    }
}