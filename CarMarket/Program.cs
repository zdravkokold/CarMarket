using CarMarket.Services.Data.Entities;
using CarMarket.Services.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CarMarket.Web.Extensions;
using CarMarket.Services.Cars;
using CarMarket.Services.Dealers;
using CarMarket.Services.Admins;

namespace CarMarket
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<CarMarketDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<ApplicationUser>(options => 
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedPhoneNumber = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<CarMarketDbContext>();
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<ICarService, CarService>();
            builder.Services.AddScoped<IDealerService, DealerService>();
            builder.Services.AddScoped<IUserService, UserService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "Areas",
                  pattern: "{area:exists}/{controller=Users}/{action=All}/{id?}"
                );

                endpoints.MapDefaultControllerRoute();                
                endpoints.MapRazorPages();
            });

            app.SeedRoles();
            app.Run();
        }
    }
}