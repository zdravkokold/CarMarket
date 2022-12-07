using CarMarket.Services.Data;
using CarMarket.Services.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarMarket.Services.Data
{
    public class CarMarketDbContext : IdentityDbContext<ApplicationUser>
    {
        public CarMarketDbContext(DbContextOptions<CarMarketDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>()
                .Property(u => u.UserName)
                .HasMaxLength(30)
                .IsRequired();

            builder.Entity<ApplicationUser>()
                .Property(u => u.Email)
                .HasMaxLength(60)
                .IsRequired();

            //builder
            // .Entity<Car>()
            // .HasData(new Car()
            // {
            //     Id = 1,
            //     Make = "Tesla",
            //     Model = "Cybertruck",
            //     YearProduced = 2022,
            //     Mileage = 147,
            //     HorsePower = 805,
            //     Color = "Grey",
            //     ImageURL = "https://i.insider.com/5dd7f73efd9db269c1036f38?width=700",
            //     Price = 39900,
            //     CategoryId = 3,
            //     EngineTypeId = 3,
            //     EuroStandardId = 6
            // });

            builder
           .Entity<Category>()
           .HasData(new Category()
           {
               Id = 1,
               Name = "Sedan"
           },
           new Category()
           {
               Id = 2,
               Name = "Hatchback"
           },
           new Category()
           {
               Id = 3,
               Name = "SUV"
           },
           new Category()
           {
               Id = 4,
               Name = "Coupe"
           },
           new Category()
           {
               Id = 5,
               Name = "Cabriolet"
           });

            builder
           .Entity<EuroStandard>()
           .HasData(new EuroStandard()
           {
               Id = 1,
               Name = "EURO 1"
           },
           new EuroStandard()
           {
               Id = 2,
               Name = "EURO 2"
           },
           new EuroStandard()
           {
               Id = 3,
               Name = "EURO 3"
           },
           new EuroStandard()
           {
               Id = 4,
               Name = "EURO 4"
           },
           new EuroStandard()
           {
               Id = 5,
               Name = "EURO 5"
           },
           new EuroStandard()
           {
               Id = 6,
               Name = "EURO 6"
           });

            builder
           .Entity<EngineType>()
           .HasData(new EngineType()
           {
               Id = 1,
               Name = "Diesel"
           },
           new EngineType()
           {
               Id = 2,
               Name = "Petrol"
           },
           new EngineType()
           {
               Id = 3,
               Name = "Electric"
           },
           new EngineType()
           {
               Id = 4,
               Name = "Hybrid"
           });

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseLazyLoadingProxies();
        }

        public DbSet<Car> Cars { get; set; } = null!;
        public DbSet<Dealer> Dealers { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<EngineType> EngineTypes { get; set; } = null!;
        public DbSet<EuroStandard> EuroStandards { get; set; } = null!;
    }
}