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

      // Put OnModelCreating HERE
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

       
    }
}