using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace KusinaKanto.Auth;

/// <summary>
/// Supplies the Blazor authentication state from the signed-in cookie user.
/// The user is captured when the circuit starts (HttpContext is available then).
/// </summary>
public class HttpContextAuthStateProvider : AuthenticationStateProvider
{
    private readonly AuthenticationState _state;

    public HttpContextAuthStateProvider(IHttpContextAccessor accessor)
    {
        var user = accessor.HttpContext?.User ?? new ClaimsPrincipal(new ClaimsIdentity());
        _state = new AuthenticationState(user);
    }

    public override Task<AuthenticationState> GetAuthenticationStateAsync() =>
        Task.FromResult(_state);
}
