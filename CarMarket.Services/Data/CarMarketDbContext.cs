using CarMarket.Services.Data;
using CarMarket.Services.Data.Configuration;
using CarMarket.Services.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarMarket.Services.Data
{
    public class CarMarketDbContext : IdentityDbContext<ApplicationUser>
    {
        private bool seedDb;

        public CarMarketDbContext(DbContextOptions<CarMarketDbContext> options, bool seed = true)
        : base(options)
        {
            if (Database.IsRelational())
            {
                Database.Migrate();
            }
            else
            {
                Database.EnsureCreated();
            }

            this.seedDb = seed;
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

            if (seedDb)
            {
                builder.ApplyConfiguration(new CarConfiguration());
                builder.ApplyConfiguration(new UserConfiguration());
                builder.ApplyConfiguration(new DealerConfiguration());
                builder.ApplyConfiguration(new CategoryConfiguration());
                builder.ApplyConfiguration(new EngineTypeConfiguration());
                builder.ApplyConfiguration(new EuroStandardConfiguration());
            }



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