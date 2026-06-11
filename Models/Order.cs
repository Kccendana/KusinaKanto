using System.ComponentModel.DataAnnotations;
namespace KusinaKanto.Models;

public enum OrderStatus
{
    Pending,
    Confirmed,
    Preparing,
    Ready,
    Completed
}

/// <summary>A placed customer order.</summary>
public class Order
{
    [Key]
    public int Id { get; set; }
    public int? TableNumber { get; set; } = null;
    public OrderType OrderType { get; set; } = OrderType.DineIn;
    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public decimal TotalAmount { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public List<OrderItem> Items { get; set; } = new();
}

