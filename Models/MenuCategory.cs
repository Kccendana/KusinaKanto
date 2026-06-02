namespace KusinaKanto.Models
{
    public class MenuCategory
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public required string Name { get; set; }
    }
}