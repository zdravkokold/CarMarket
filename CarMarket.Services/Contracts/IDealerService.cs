using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMarket.Services.Contracts
{
    public interface IDealerService
    {
        Task<bool> ExistsById(string userId);

        Task<bool> UserWithPhoneNumberExists(string phoneNumber);

        Task<bool> UserHasCars(string userId);

        Task Create(string userId, string phoneNumber);

        Task<int> GetDealerId(string userId);
    }
}
