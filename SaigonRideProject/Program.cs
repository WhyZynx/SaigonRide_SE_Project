using Microsoft.EntityFrameworkCore;
using SaigonRideProject.Data;
using SaigonRideProject.Services;
using SaigonRideProject.Services.Pricing;

public partial class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();

        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnection")
            ));

        builder.Services.AddScoped<EmailService>();
        builder.Services.AddScoped<FileUploadService>();
        builder.Services.AddScoped<PassportService>();
        builder.Services.AddScoped<IPricingStrategy, DefaultPricingService>();
        builder.Services.AddScoped<RentalService>();
        builder.Services.AddScoped<WalletService>();
        builder.Services.AddAuthentication();
        builder.Services.AddAuthorization();

        builder.Services.AddSession();

        var app = builder.Build();

        app.UseStaticFiles();
        app.UseRouting();
        app.UseSession();
        app.UseDeveloperExceptionPage();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.MapControllerRoute(
        name: "admin",
        pattern: "admin/{controller=Admin}/{action=Dashboard}/{id?}");
        app.Run();
    }
}