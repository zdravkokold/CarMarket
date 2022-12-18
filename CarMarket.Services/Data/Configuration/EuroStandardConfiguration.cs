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
    public class EuroStandardConfiguration : IEntityTypeConfiguration<EuroStandard>
    {
        public void Configure(EntityTypeBuilder<EuroStandard> builder)
        {
            builder.HasData(CreateEuroStandards());
        }

        private List<EuroStandard> CreateEuroStandards()
        {
            List<EuroStandard> euros = new List<EuroStandard>()
            {
              new EuroStandard()
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
              }
             };

            return euros;
        }
    }
}
