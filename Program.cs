using KusinaKanto.Components;
using KusinaKanto.Services;
using Microsoft.EntityFrameworkCore;
using KusinaKanto.Data;

var builder = WebApplication.CreateBuilder(args);

// Blazor Server (interactive Razor components).
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Data layer — EF Core + SQLite. The UI depends only on IMenuService / IOrderService.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Data Source=KusinaKanto.db";
builder.Services.AddDbContext<KusinaKantoDbContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddScoped<IMenuService, EfMenuService>();
builder.Services.AddScoped<IOrderService, EfOrderService>();

// Admin-side CRUD services.
builder.Services.AddScoped<IMenuAdminService, EfMenuAdminService>();
builder.Services.AddScoped<IStaffService, EfStaffService>();

// Per-session cart.
builder.Services.AddScoped<CartState>();

var app = builder.Build();
// Seed the database with initial menu data if it's empty.
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider
        .GetRequiredService<KusinaKantoDbContext>();

    await DbInitializer.SeedAsync(db);
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
