using Microsoft.EntityFrameworkCore;
using KusinaKanto.Models;

namespace KusinaKanto.Data;

public class KusinaKantoDbContext : DbContext
{
    public KusinaKantoDbContext(
        DbContextOptions<KusinaKantoDbContext> options)
        : base(options)
    {
    }

    public DbSet<MenuCategory> MenuCategories => Set<MenuCategory>();

    public DbSet<MenuItem> MenuItems => Set<MenuItem>();

    public DbSet<Order> Orders => Set<Order>();

    public DbSet<OrderItem> OrderItems => Set<OrderItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // An order owns its line items; deleting an order removes them too.
        modelBuilder.Entity<Order>()
            .HasMany(o => o.Items)
            .WithOne()
            .OnDelete(DeleteBehavior.Cascade);
    }
}