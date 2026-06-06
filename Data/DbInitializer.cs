using Microsoft.EntityFrameworkCore;
using KusinaKanto.Models;

namespace KusinaKanto.Data;

public static class DbInitializer
{
    public static async Task SeedAsync(KusinaKantoDbContext db)
    {
        db.Database.EnsureCreated();

        if (db.MenuCategories.Any() || db.MenuItems.Any())
            return;

        // -----------------------
        // CATEGORIES
        // -----------------------
        var categories = new List<MenuCategory>
        {
            new() { Id = "starters", Name = "Starters", Description = "Light bites and appetizers", DisplayOrder = 1 },
            new() { Id = "soups", Name = "Soups & Stews", Description = "Hearty Filipino soups", DisplayOrder = 2 },
            new() { Id = "rice", Name = "Rice Dishes", Description = "Classic rice-based mains", DisplayOrder = 3 },
            new() { Id = "grilled", Name = "Grilled & Fried", Description = "BBQ and fried favorites", DisplayOrder = 4 },
            new() { Id = "noodles", Name = "Noodles", Description = "Pancit and noodle dishes", DisplayOrder = 5 },
            new() { Id = "desserts", Name = "Desserts", Description = "Sweet Filipino treats", DisplayOrder = 6 },
            new() { Id = "drinks", Name = "Drinks", Description = "Refreshing beverages", DisplayOrder = 7 }
        };

        db.MenuCategories.AddRange(categories);

        // -----------------------
        // MENU ITEMS (ALL 24)
        // -----------------------
        db.MenuItems.AddRange(

            // Starters
            new MenuItem { Id="i1", CategoryId="starters", Name="Lumpia Shanghai", Description="Crispy fried spring rolls filled with seasoned ground pork, carrots, and vegetables. Served with sweet chili sauce.", Price=8.99m, ImageUrl=Img("1640777"), IsAvailable=true, IsBestseller=true },
            new MenuItem { Id="i2", CategoryId="starters", Name="Tokwa't Baboy", Description="Deep-fried tofu and pork ears marinated in vinegar, soy sauce, garlic and chili.", Price=9.99m, ImageUrl=Img("769289"), IsAvailable=true, IsSpicy=true },
            new MenuItem { Id="i3", CategoryId="starters", Name="Kare-Kare Starter", Description="Oxtail and vegetables in rich peanut sauce with bagoong.", Price=12.99m, ImageUrl=Img("1410235"), IsAvailable=true },

            // Soups & Stews
            new MenuItem { Id="i4", CategoryId="soups", Name="Sinigang na Baboy", Description="Pork ribs in sour tamarind broth with vegetables.", Price=14.99m, ImageUrl=Img("2664216"), IsAvailable=true, IsBestseller=true },
            new MenuItem { Id="i5", CategoryId="soups", Name="Bulalo", Description="Slow-cooked beef shank soup with corn and cabbage.", Price=18.99m, ImageUrl=Img("539451"), IsAvailable=true, IsBestseller=true },
            new MenuItem { Id="i6", CategoryId="soups", Name="Tinola", Description="Chicken ginger soup with papaya and chili leaves.", Price=13.99m, ImageUrl=Img("1279330"), IsAvailable=true },

            // Rice Dishes
            new MenuItem { Id="i7", CategoryId="rice", Name="Adobo sa Gata", Description="Chicken and pork adobo in coconut milk.", Price=15.99m, ImageUrl=Img("2338407"), IsAvailable=true, IsBestseller=true },
            new MenuItem { Id="i8", CategoryId="rice", Name="Kare-Kare", Description="Oxtail and vegetables in peanut sauce.", Price=19.99m, ImageUrl=Img("1640772"), IsAvailable=true },
            new MenuItem { Id="i9", CategoryId="rice", Name="Bistek Tagalog", Description="Beef with soy-citrus sauce and onions.", Price=17.99m, ImageUrl=Img("1410234"), IsAvailable=true },
            new MenuItem { Id="i10", CategoryId="rice", Name="Dinuguan", Description="Pork blood stew with vinegar and spices.", Price=13.99m, ImageUrl=Img("3616956"), IsAvailable=true, IsSpicy=true },

            // Grilled & Fried
            new MenuItem { Id="i11", CategoryId="grilled", Name="Lechon Kawali", Description="Crispy deep-fried pork belly.", Price=16.99m, ImageUrl=Img("2673353"), IsAvailable=true, IsBestseller=true },
            new MenuItem { Id="i12", CategoryId="grilled", Name="Inihaw na Liempo", Description="Grilled marinated pork belly.", Price=15.99m, ImageUrl=Img("1860208"), IsAvailable=true, IsBestseller=true },
            new MenuItem { Id="i13", CategoryId="grilled", Name="Crispy Pata", Description="Deep-fried pork leg with crispy skin.", Price=28.99m, ImageUrl=Img("2491270"), IsAvailable=true },

            // Noodles
            new MenuItem { Id="i14", CategoryId="noodles", Name="Pancit Canton", Description="Stir-fried noodles with meat and vegetables.", Price=12.99m, ImageUrl=Img("1279330"), IsAvailable=true, IsBestseller=true },
            new MenuItem { Id="i15", CategoryId="noodles", Name="Pancit Malabon", Description="Thick noodles with seafood sauce.", Price=14.99m, ImageUrl=Img("1640777"), IsAvailable=true },
            new MenuItem { Id="i16", CategoryId="noodles", Name="Bihon Guisado", Description="Rice noodles with vegetables and meat.", Price=11.99m, ImageUrl=Img("2664216"), IsAvailable=true },

            // Desserts
            new MenuItem { Id="i17", CategoryId="desserts", Name="Halo-Halo", Description="Mixed shaved ice dessert with toppings.", Price=7.99m, ImageUrl=Img("1099680"), IsAvailable=true, IsBestseller=true },
            new MenuItem { Id="i18", CategoryId="desserts", Name="Leche Flan", Description="Creamy caramel custard dessert.", Price=5.99m, ImageUrl=Img("1414234"), IsAvailable=true, IsBestseller=true },
            new MenuItem { Id="i19", CategoryId="desserts", Name="Ube Halaya", Description="Purple yam jam dessert.", Price=6.99m, ImageUrl=Img("1099681"), IsAvailable=true },
            new MenuItem { Id="i20", CategoryId="desserts", Name="Bibingka", Description="Rice cake baked in banana leaves.", Price=5.99m, ImageUrl=Img("1640772"), IsAvailable=true },

            // Drinks
            new MenuItem { Id="i21", CategoryId="drinks", Name="Calamansi Juice", Description="Fresh citrus juice.", Price=3.99m, ImageUrl=Img("1435735"), IsAvailable=true },
            new MenuItem { Id="i22", CategoryId="drinks", Name="Sago't Gulaman", Description="Sweet drink with tapioca and jelly.", Price=4.49m, ImageUrl=Img("2109099"), IsAvailable=true, IsBestseller=true },
            new MenuItem { Id="i23", CategoryId="drinks", Name="Buko Juice", Description="Fresh coconut water.", Price=4.99m, ImageUrl=Img("1435735"), IsAvailable=true },
            new MenuItem { Id="i24", CategoryId="drinks", Name="Iced Coffee", Description="Filipino-style iced coffee with milk.", Price=4.49m, ImageUrl=Img("2109099"), IsAvailable=true }
        );

        await db.SaveChangesAsync();
        Console.WriteLine($"Categories: {db.MenuCategories.Count()}");
        Console.WriteLine($"Items: {db.MenuItems.Count()}");
    }

    private static string Img(string id)
        => $"https://images.pexels.com/photos/{id}/pexels-photo-{id}.jpeg";
}