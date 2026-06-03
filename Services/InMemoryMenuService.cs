using KusinaKanto.Models;

namespace KusinaKanto.Services;

/// <summary>
/// Temporary in-memory menu, seeded with the same data the design was built on.
/// Lets the UI render and run standalone today. Replace with the EF Core +
/// SQL Server implementation when the backend is ready (same <see cref="IMenuService"/>).
/// </summary>
public class InMemoryMenuService : IMenuService
{
    private static string Img(string id) => $"https://images.pexels.com/photos/{id}/pexels-photo-{id}.jpeg";

    private static readonly List<MenuCategory> Categories = new()
    {
        new() { Id = "starters", Name = "Starters",        Description = "Light bites and appetizers", DisplayOrder = 1 },
        new() { Id = "soups",    Name = "Soups & Stews",   Description = "Hearty Filipino soups",       DisplayOrder = 2 },
        new() { Id = "rice",     Name = "Rice Dishes",     Description = "Classic rice-based mains",     DisplayOrder = 3 },
        new() { Id = "grilled",  Name = "Grilled & Fried", Description = "BBQ and fried favorites",      DisplayOrder = 4 },
        new() { Id = "noodles",  Name = "Noodles",         Description = "Pancit and noodle dishes",     DisplayOrder = 5 },
        new() { Id = "desserts", Name = "Desserts",        Description = "Sweet Filipino treats",        DisplayOrder = 6 },
        new() { Id = "drinks",   Name = "Drinks",          Description = "Refreshing beverages",         DisplayOrder = 7 },
    };

    private static readonly List<MenuItem> Items = new()
    {
        // Starters
        new() { Id = "i1",  CategoryId = "starters", Name = "Lumpia Shanghai",   Description = "Crispy fried spring rolls filled with seasoned ground pork, carrots, and vegetables. Served with sweet chili sauce.", Price = 8.99m,  ImageUrl = Img("1640777"), IsBestseller = true },
        new() { Id = "i2",  CategoryId = "starters", Name = "Tokwa't Baboy",     Description = "Deep-fried tofu and pork ears marinated in vinegar, soy sauce, garlic and chili. A perfect pulutan.", Price = 9.99m,  ImageUrl = Img("769289"),  IsSpicy = true },
        new() { Id = "i3",  CategoryId = "starters", Name = "Kare-Kare Starter", Description = "Oxtail and vegetables in rich peanut sauce, served with fermented shrimp paste.", Price = 12.99m, ImageUrl = Img("1410235") },

        // Soups & Stews
        new() { Id = "i4",  CategoryId = "soups", Name = "Sinigang na Baboy", Description = "Pork ribs in sour tamarind broth with vegetables. A quintessential Filipino comfort soup.", Price = 14.99m, ImageUrl = Img("2664216"), IsBestseller = true },
        new() { Id = "i5",  CategoryId = "soups", Name = "Bulalo",            Description = "Slow-cooked beef shank and bone marrow soup. Rich, collagen-filled broth with corn and cabbage.", Price = 18.99m, ImageUrl = Img("539451"),  IsBestseller = true },
        new() { Id = "i6",  CategoryId = "soups", Name = "Tinola",            Description = "Chicken ginger soup with papaya wedges and chili leaves. Light and nourishing.", Price = 13.99m, ImageUrl = Img("1279330") },

        // Rice Dishes
        new() { Id = "i7",  CategoryId = "rice", Name = "Adobo sa Gata",  Description = "Chicken and pork adobo simmered in coconut milk. Creamy, tangy, and deeply savory.", Price = 15.99m, ImageUrl = Img("2338407"), IsBestseller = true },
        new() { Id = "i8",  CategoryId = "rice", Name = "Kare-Kare",      Description = "Oxtail, tripe, and vegetables in rich peanut sauce. Served with bagoong alamang.", Price = 19.99m, ImageUrl = Img("1640772") },
        new() { Id = "i9",  CategoryId = "rice", Name = "Bistek Tagalog", Description = "Sliced beef tenderloin in soy-citrus marinade with caramelized onion rings.", Price = 17.99m, ImageUrl = Img("1410234") },
        new() { Id = "i10", CategoryId = "rice", Name = "Dinuguan",       Description = "Pork blood stew — savory, tangy, and spicy. Served with puto rice cakes.", Price = 13.99m, ImageUrl = Img("3616956"), IsSpicy = true },

        // Grilled & Fried
        new() { Id = "i11", CategoryId = "grilled", Name = "Lechon Kawali",     Description = "Crispy fried pork belly, golden outside, tender inside. Served with lechon sauce.", Price = 16.99m, ImageUrl = Img("2673353"), IsBestseller = true },
        new() { Id = "i12", CategoryId = "grilled", Name = "Inihaw na Liempo",  Description = "Grilled marinated pork belly with signature BBQ sauce. Smoky and caramelized.", Price = 15.99m, ImageUrl = Img("1860208"), IsBestseller = true },
        new() { Id = "i13", CategoryId = "grilled", Name = "Crispy Pata",       Description = "Whole deep-fried pork leg, incredibly crispy skin with juicy meat inside.", Price = 28.99m, ImageUrl = Img("2491270") },

        // Noodles
        new() { Id = "i14", CategoryId = "noodles", Name = "Pancit Canton",  Description = "Stir-fried egg noodles with pork, shrimp, and vegetables in savory sauce.", Price = 12.99m, ImageUrl = Img("1279330"), IsBestseller = true },
        new() { Id = "i15", CategoryId = "noodles", Name = "Pancit Malabon", Description = "Thick rice noodles in rich seafood sauce topped with shrimp, squid, and chicharron.", Price = 14.99m, ImageUrl = Img("1640777") },
        new() { Id = "i16", CategoryId = "noodles", Name = "Bihon Guisado",  Description = "Sauteed rice vermicelli with chicken, pork, and mixed vegetables.", Price = 11.99m, ImageUrl = Img("2664216") },

        // Desserts
        new() { Id = "i17", CategoryId = "desserts", Name = "Halo-Halo",   Description = "Shaved ice dessert with sweet beans, fruits, leche flan, ube, and evaporated milk.", Price = 7.99m, ImageUrl = Img("1099680"), IsBestseller = true },
        new() { Id = "i18", CategoryId = "desserts", Name = "Leche Flan",  Description = "Silky smooth caramel custard, a Filipino classic. Rich and decadent.", Price = 5.99m, ImageUrl = Img("1414234"), IsBestseller = true },
        new() { Id = "i19", CategoryId = "desserts", Name = "Ube Halaya",  Description = "Purple yam jam — sweet, creamy, and fragrant. Topped with latik coconut curds.", Price = 6.99m, ImageUrl = Img("1099681") },
        new() { Id = "i20", CategoryId = "desserts", Name = "Bibingka",    Description = "Traditional rice cake baked in banana leaf with salted egg and fresh coconut.", Price = 5.99m, ImageUrl = Img("1640772") },

        // Drinks
        new() { Id = "i21", CategoryId = "drinks", Name = "Calamansi Juice", Description = "Fresh Filipino lime juice, lightly sweetened. Refreshing and citrusy.", Price = 3.99m, ImageUrl = Img("1435735") },
        new() { Id = "i22", CategoryId = "drinks", Name = "Sago't Gulaman",  Description = "Sweet iced drink with tapioca pearls and gelatin in brown sugar syrup.", Price = 4.49m, ImageUrl = Img("2109099"), IsBestseller = true },
        new() { Id = "i23", CategoryId = "drinks", Name = "Buko Juice",      Description = "Fresh young coconut water, naturally sweet and hydrating.", Price = 4.99m, ImageUrl = Img("1435735") },
        new() { Id = "i24", CategoryId = "drinks", Name = "Iced Coffee",     Description = "Filipino-style strong brewed coffee with condensed milk over ice.", Price = 4.49m, ImageUrl = Img("2109099") },
    };

    public Task<IReadOnlyList<MenuCategory>> GetCategoriesAsync() =>
        Task.FromResult<IReadOnlyList<MenuCategory>>(Categories.OrderBy(c => c.DisplayOrder).ToList());

    public Task<IReadOnlyList<MenuItem>> GetAvailableItemsAsync() =>
        Task.FromResult<IReadOnlyList<MenuItem>>(Items.Where(i => i.IsAvailable).ToList());
}
