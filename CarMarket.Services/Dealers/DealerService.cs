using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarMarket.Services.Data.Entities;
using CarMarket.Services.Data;
using Microsoft.AspNetCore.Identity;

namespace CarMarket.Services.Dealers
{
    public class DealerService : IDealerService
    {
        private readonly CarMarketDbContext data;

        private readonly UserManager<ApplicationUser> userManager;

        public DealerService(CarMarketDbContext data, UserManager<ApplicationUser> userManager
            )
        {
            this.data = data;
            this.userManager = userManager;
        }

        public void Create(string userId, string phoneNumber)
        {
            var dealer = new Dealer()
            {
                UserId = userId,
                PhoneNumber = phoneNumber
            };

            var user = data.Users.First(x => x.Id == userId);
            
            userManager.RemoveFromRoleAsync(user, "User");
            userManager.AddToRoleAsync(user, "Admin");

            data.Dealers.Add(dealer);
            data.SaveChanges();
        }

        public bool ExistsById(string userId)
        {
            return data.Dealers.Any(d => d.UserId == userId);
        }

        public int GetDealerId(string userId)
        {
            return data.Dealers.FirstOrDefault(d => d.UserId == userId)?.Id ?? 0;
        }

        public bool UserHasCars(string userId)
        {
            return data.Cars.Any(d => d.OwnerId == userId);
        }

        public bool UserWithPhoneNumberExists(string phoneNumber)
        {
            return data.Dealers.Any(d => d.PhoneNumber == phoneNumber);
        }
    }
}