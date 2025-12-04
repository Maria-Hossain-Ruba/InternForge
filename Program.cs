using InternForge.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// ---------------------------------------------------------
// 1. Load connection string from appsettings.json
// ---------------------------------------------------------
var connectionString = builder.Configuration.GetConnectionString("InternForgeConnection")
    ?? throw new InvalidOperationException("Connection string 'InternForgeConnection' not found.");

// ---------------------------------------------------------
// 2. Register DbContext for SQL Server
// ---------------------------------------------------------
builder.Services.AddDbContext<InternForgeContext>(options =>
    options.UseSqlServer(connectionString));

// ---------------------------------------------------------
// 3. Add MVC Services
// ---------------------------------------------------------
builder.Services.AddControllersWithViews();

var app = builder.Build();

// ---------------------------------------------------------
// 4. Configure HTTP Request Pipeline
// ---------------------------------------------------------
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// Needed for CSS, JS, images
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// ---------------------------------------------------------
// 5. Configure MVC Routing
//    Set Student/Dashboard as the default page
// ---------------------------------------------------------
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Student}/{action=Dashboard}/{id?}");

app.Run();
