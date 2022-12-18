using CarMarket.Services.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMarket.Services.Data.Configuration
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(CreateCategories());
        }

        private List<Category> CreateCategories()
        {
            List<Category> categories = new List<Category>()
            {
              new Category()
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
              }

             };

            return categories;
        }
    }
}
