using KusinaKanto.Models;

namespace KusinaKanto.Services;

/// <summary>
/// Holds the customer's in-progress cart for the lifetime of their session (circuit).
/// Components subscribe to <see cref="OnChange"/> to re-render when the cart updates.
/// </summary>
public class CartState
{
    public List<CartLine> Lines { get; } = new();

    public event Action? OnChange;

    public int Count => Lines.Sum(l => l.Quantity);
    public decimal Total => Lines.Sum(l => l.Subtotal);
    public int QuantityOf(string itemId) => Lines.FirstOrDefault(l => l.Item.Id == itemId)?.Quantity ?? 0;

    public void Add(MenuItem item)
    {
        var line = Lines.FirstOrDefault(l => l.Item.Id == item.Id);
        if (line is null)
            Lines.Add(new CartLine { Item = item, Quantity = 1 });
        else
            line.Quantity++;
        NotifyChanged();
    }

    public void Remove(string itemId)
    {
        var line = Lines.FirstOrDefault(l => l.Item.Id == itemId);
        if (line is null) return;
        if (line.Quantity <= 1)
            Lines.Remove(line);
        else
            line.Quantity--;
        NotifyChanged();
    }

    public void Clear()
    {
        Lines.Clear();
        NotifyChanged();
    }

    // Hand-off from checkout to the confirmation page.
    public Order? LastOrder { get; set; }
    public List<CartLine> LastItems { get; set; } = new();

    private void NotifyChanged() => OnChange?.Invoke();
}
