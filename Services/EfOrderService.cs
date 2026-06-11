using KusinaKanto.Data;
using KusinaKanto.Models;

namespace KusinaKanto.Services;

/// <summary>
/// Persists placed orders (and their line items) to the database via EF Core.
/// </summary>
public class EfOrderService : IOrderService
{
    private readonly KusinaKantoDbContext _db;

    public EfOrderService(KusinaKantoDbContext db)
    {
        _db = db;
    }

    public async Task<Order> PlaceOrderAsync(Order order)
{
    order.Status = OrderStatus.Pending;

    _db.Orders.Add(order);
    await _db.SaveChangesAsync();

    return order;
}
}
