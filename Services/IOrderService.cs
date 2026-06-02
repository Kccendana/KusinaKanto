using KusinaKanto.Models;

namespace KusinaKanto.Services;

/// <summary>
/// Persists placed orders. UI calls this only; swap <see cref="InMemoryOrderService"/>
/// for the EF Core + SQL Server implementation when the backend is ready.
/// </summary>
public interface IOrderService
{
    Task<Order> PlaceOrderAsync(Order order);
}
