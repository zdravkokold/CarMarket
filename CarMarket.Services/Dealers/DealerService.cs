using CarMarket.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarMarket.Services.Data.Entities;
using CarMarket.Services.Data;

namespace CarMarket.Services.Services
{
    public class DealerService : IDealerService
    {
        private readonly CarMarketDbContext data;

        public DealerService(CarMarketDbContext data)
        {
            this.data = data;
        }

        public async Task Create(string userId, string phoneNumber)
        {
            var dealer = new Dealer()
            {
                UserId = userId,
                PhoneNumber = phoneNumber
            };
            
            await data.Dealers.AddAsync(dealer);
            await data.SaveChangesAsync();
        }

        public async Task<bool> ExistsById(string userId)
        {
            return data.Dealers.Any(d => d.UserId == userId);
        }

        public async Task<int> GetDealerId(string userId)
        {
            return data.Dealers.FirstOrDefault(d => d.UserId == userId)?.Id ?? 0;
        }

        public async Task<bool> UserHasCars(string userId)
        {
            return data.Cars.Any(d => d.OwnerId == userId);
        }

        public async Task<bool> UserWithPhoneNumberExists(string phoneNumber)
        {
            return data.Dealers.Any(d => d.PhoneNumber == phoneNumber);
        }
    }
}