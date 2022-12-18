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
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {        
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
           builder.HasData(CreateUsers());
        }

        private List<ApplicationUser> CreateUsers()
        {
            var users = new List<ApplicationUser>();
            var hasher = new PasswordHasher<ApplicationUser>();
                        
            var user = new ApplicationUser()
            {
                Id = "6d0000ce-d726-4fc8-00d9-d6b3ac1f001e",
                UserName = "zdravko",
                FirstName = "Zdravko",
                LastName = "Koldzhiev",
                NormalizedUserName = "zdravko",
                Email = "zdravko@mail.com",
                NormalizedEmail = "zdravko@mail.com"
            };

            user.PasswordHash =
            hasher.HashPassword(user, "12345z");
                      
            users.Add(user);

            return users;
        }

    }
}
