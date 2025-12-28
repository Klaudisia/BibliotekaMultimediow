using Microsoft.EntityFrameworkCore;
using BibliotekaProjekt.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Konfiguracja bazy SQLite (To musi być PRZED builder.Build())
builder.Services.AddDbContext<BibliotekaContext>(options =>
    options.UseSqlite("Data Source=biblioteka.db"));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.Run();