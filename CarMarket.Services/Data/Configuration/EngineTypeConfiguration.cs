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
    public class EngineTypeConfiguration : IEntityTypeConfiguration<EngineType>
    {
        public void Configure(EntityTypeBuilder<EngineType> builder)
        {
            builder.HasData(CreateEngineTypes());
        }

        private List<EngineType> CreateEngineTypes()
        {
            List<EngineType> engineTypes = new List<EngineType>()
            {
              new EngineType()
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
              }
             };

            return engineTypes;
        }
    }
}
