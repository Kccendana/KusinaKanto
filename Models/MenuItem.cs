namespace KusinaKanto.Models
{
    public class MenuItem
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string Name { get; set; }
    public string Description { get; set; }

    public decimal Price { get; set; }
    public string ImageUrl { get; set; }

    public bool IsAvailable { get; set; }

    public string CategoryId { get; set; }
}
}