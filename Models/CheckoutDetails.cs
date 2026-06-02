namespace KusinaKanto.Models;

/// <summary>The customer details collected by the checkout form.</summary>
public class CheckoutDetails
{
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public string Table { get; set; } = "";
    public string Notes { get; set; } = "";
}
