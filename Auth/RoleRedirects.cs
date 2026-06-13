using KusinaKanto.Models;

namespace KusinaKanto.Auth;

public static class RoleRedirects
{
    public static string GetHomePage(StaffRole role)
    {
        return role switch
        {
            StaffRole.Admin => "/admin",
            StaffRole.Kitchen => "/kitchen",
            StaffRole.Cashier => "/cashier",
            _ => "/"
        };
    }
}