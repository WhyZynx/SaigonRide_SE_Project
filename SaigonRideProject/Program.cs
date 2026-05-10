using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using SaigonRideProject.Data;
using SaigonRideProject.Services;
using SaigonRideProject.Services.Pricing;
using System.Globalization;

namespace SaigonRideProject
{
    public partial class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services
                    .AddControllersWithViews()
                    .AddViewLocalization()
                    .AddDataAnnotationsLocalization();

            builder.Services.AddLocalization(options =>
                options.ResourcesPath = "Resourcey");

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")
                ));

            builder.Services.AddScoped<EmailService>();
            builder.Services.AddScoped<IPricingStrategy, DefaultPricingService>();
            builder.Services.AddScoped<RentalService>();
            builder.Services.AddScoped<WalletService>();
            builder.Services.AddScoped<StationService>();

            builder.Services.AddSession();

            var app = builder.Build();

            var supportedCultures = new[]
            {
                new CultureInfo("en"),
                new CultureInfo("vi")
            };

            var localizationOptions = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            };

            localizationOptions.RequestCultureProviders = new List<IRequestCultureProvider>
            {
                new CookieRequestCultureProvider(),
                new QueryStringRequestCultureProvider()
            };

            app.UseRequestLocalization(localizationOptions); 
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();  

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "admin",
                pattern: "admin/{controller=Admin}/{action=Dashboard}/{id?}");

            app.Run();
        }
    }
}