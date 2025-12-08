using InternForge.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using static InternForge.Models.Auth.IdentityModel;

var builder = WebApplication.CreateBuilder(args);

// Database
builder.Services.AddDbContext<InternForgeContext>((sp, options) =>
{
    var config = sp.GetRequiredService<IConfiguration>();

    options.UseSqlServer(config.GetConnectionString("DefaultConnection"))
           .ConfigureWarnings(warnings =>
               warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
    var loggerFactory = sp.GetRequiredService<ILoggerFactory>();
    options.UseLoggerFactory(loggerFactory);
    options.LogTo(Console.WriteLine, LogLevel.Information);
});

// Identity
builder.Services.AddIdentity<User, Role>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = false;
})
.AddEntityFrameworkStores<InternForgeContext>()
.AddDefaultTokenProviders();

builder.Services.AddHttpContextAccessor();

// Authorization
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CanPurge", policy => policy.RequireRole("SME"));
});

// MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

// Routes
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
