using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMarket.Services.Dealers
{
    public interface IDealerService
    {
        bool ExistsById(string userId);

        bool UserWithPhoneNumberExists(string phoneNumber);

        bool UserHasCars(string userId);

        void Create(string userId, string phoneNumber);

        int GetDealerId(string userId);
    }
}
