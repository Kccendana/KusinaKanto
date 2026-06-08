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
        order.Id = Guid.NewGuid().ToString("N");
        order.CreatedAt = DateTime.Now;
        order.Status = OrderStatus.Pending;

        // The UI builds order items without ids; give each a primary key so they
        // don't collide on the empty-string default.
        foreach (var item in order.Items)
        {
            item.Id = Guid.NewGuid().ToString("N");
        }

        _db.Orders.Add(order);
        await _db.SaveChangesAsync();
        return order;
    }
}
