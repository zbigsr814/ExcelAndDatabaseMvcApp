using ExcelAndDatabaseMvcApp.Entities;
using ExcelAndDatabaseMvcApp.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<CompanySeeder>();

builder.Services.AddDbContext<CompanyDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("Company")));

var app = builder.Build();

// Seedowanie danych przy starcie aplikacji
using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<CompanySeeder>();
    seeder.Seed(); // Wywo³anie metody seeduj¹cej dane
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
