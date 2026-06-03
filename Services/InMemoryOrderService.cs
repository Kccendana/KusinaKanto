using KusinaKanto.Models;

namespace KusinaKanto.Services;

/// <summary>
/// Stub order store so checkout works end-to-end in the UI today.
/// Orders live in memory for the app's lifetime. The real backend persists to SQL Server.
/// </summary>
public class InMemoryOrderService : IOrderService
{
    private readonly List<Order> _orders = new();

    public Task<Order> PlaceOrderAsync(Order order)
    {
        order.Id = Guid.NewGuid().ToString("N");
        order.CreatedAt = DateTime.Now;
        order.Status = OrderStatus.Pending;
        _orders.Add(order);
        return Task.FromResult(order);
    }
}
