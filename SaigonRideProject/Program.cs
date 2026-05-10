using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SaigonRideProject.Data;
using SaigonRideProject.Services;
using SaigonRideProject.Services.Pricing;
namespace SaigonRideProject
{


    public partial class Program
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite(
                    builder.Configuration.GetConnectionString("DefaultConnection")
                ));

            builder.Services.AddScoped<EmailService>();
            builder.Services.AddScoped<IPricingStrategy, DefaultPricingService>();
            builder.Services.AddScoped<RentalService>();
            builder.Services.AddScoped<WalletService>();
            builder.Services.AddScoped<StationService>();

            builder.Services.AddSession();

            builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

            builder.Services.AddControllersWithViews()
            .AddViewLocalization()
            .AddDataAnnotationsLocalization(options => {
                options.DataAnnotationLocalizerProvider = (type, factory) =>
                    factory.Create(typeof(SaigonRideProject.Resources.SharedResource));
            });

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var factory = scope.ServiceProvider.GetRequiredService<IStringLocalizerFactory>();
                SaigonRideProject.Helpers.Locale.Init(factory);
            }

            var supportedCultures = new[] { "en-US", "vi-VN" };

            var localizationOptions = new RequestLocalizationOptions()
                .SetDefaultCulture("en-US")
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures);

            localizationOptions.RequestCultureProviders.Insert(0, new CookieRequestCultureProvider());
            app.UseRequestLocalization(localizationOptions);

            app.Use(async (context, next) =>
            {
                var culture = context.Features.Get<IRequestCultureFeature>();
                if (culture != null)
                {
                    var requestCulture = culture.RequestCulture;
                    System.Globalization.CultureInfo.CurrentCulture = requestCulture.Culture;
                    System.Globalization.CultureInfo.CurrentUICulture = requestCulture.UICulture;
                }
                await next();
            });

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
}