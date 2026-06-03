using KusinaKanto.Components;
using KusinaKanto.Services;

var builder = WebApplication.CreateBuilder(args);

// Blazor Server (interactive Razor components).
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Data seam — swap these in-memory implementations for the EF Core + SQL Server
// backend when it's ready; the UI depends only on the interfaces.
builder.Services.AddSingleton<IMenuService, InMemoryMenuService>();
builder.Services.AddScoped<IOrderService, InMemoryOrderService>();

// Per-session cart.
builder.Services.AddScoped<CartState>();

var app = builder.Build();

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
