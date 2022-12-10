using CarMarket.Services.Data;
using HouseRentingSystem.Core.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMarket.Services.Admins
{
    public class UserService : IUserService
    {
        private readonly CarMarketDbContext data;
        public UserService(CarMarketDbContext data)
        {
            this.data = data;
        }
        public async Task<IEnumerable<UserServiceModel>> All()
        {
            List<UserServiceModel> result;

            result = data.Dealers
                .Select(a => new UserServiceModel()
                {
                    UserId = a.UserId,
                    Email = a.User.Email,
                    FullName = $"{a.User.FirstName} {a.User.LastName}",
                    PhoneNumber = a.PhoneNumber
                })
                .ToList();

            string[] dealerIds = result.Select(a => a.UserId).ToArray();

            result.AddRange(data.Users
                .Where(u => dealerIds.Contains(u.Id) == false)
                .Select(u => new UserServiceModel()
                {
                    UserId = u.Id,
                    Email = u.Email,
                    FullName = $"{u.FirstName} {u.LastName}"
                })
                .ToList());

            return result;
        }

        public async Task<string> UserFullName(string userId)
        {
            var user = data.Users.Find(userId);

            return $"{user?.FirstName} {user?.LastName}".Trim();
        }
    }
}
