using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace AquaHub.Mobile.Services;

public class MobileAuthenticationStateProvider : AuthenticationStateProvider
{
    // For now, this is a simple implementation that assumes a single user on the device
    // In a real app, you'd store credentials securely and validate them
    private ClaimsPrincipal _currentUser = new ClaimsPrincipal(new ClaimsIdentity());

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        // For mobile local-only mode, create a default authenticated user
        var identity = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.NameIdentifier, "mobile-user-1"),
            new Claim(ClaimTypes.Name, "Mobile User"),
        }, "mobile");

        _currentUser = new ClaimsPrincipal(identity);
        return Task.FromResult(new AuthenticationState(_currentUser));
    }

    public void MarkUserAsAuthenticated(string userId, string userName)
    {
        var identity = new ClaimsIdentity(new[]
        {
            new Claim(ClaimTypes.NameIdentifier, userId),
            new Claim(ClaimTypes.Name, userName),
        }, "mobile");

        _currentUser = new ClaimsPrincipal(identity);
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_currentUser)));
    }

    public void MarkUserAsLoggedOut()
    {
        _currentUser = new ClaimsPrincipal(new ClaimsIdentity());
        NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_currentUser)));
    }
}
