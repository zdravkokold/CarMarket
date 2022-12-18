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
    internal class DealerConfiguration : IEntityTypeConfiguration<Dealer>
    {
        public void Configure(EntityTypeBuilder<Dealer> builder)
        {
            builder.HasData(new Dealer()
            {
                Id = 1,
                PhoneNumber = "+359000888999",
                UserId = "6d0000ce-d726-4fc8-00d9-d6b3ac1f001e"
            });
        }
    }
}
