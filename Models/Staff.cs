using System.ComponentModel.DataAnnotations;

namespace KusinaKanto.Models;

public enum StaffRole
{
    Admin,
    Cashier,
    Kitchen
}

/// <summary>A staff member who works at the restaurant.</summary>
public class Staff
{
    [Key]
    public string Id { get; set; } = "";
    public string Name { get; set; } = "";
    public StaffRole Role { get; set; } = StaffRole.Cashier;
    public string Email { get; set; } = "";
    public string Phone { get; set; } = "";
    public bool IsActive { get; set; } = true;

    /// <summary>Hashed login password. Empty for staff who can't sign in.</summary>
    public string PasswordHash { get; set; } = "";
}
