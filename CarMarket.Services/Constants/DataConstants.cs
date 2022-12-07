using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMarket.Services.Constants
{
    public class DataConstants
    {
        public class ApplicationUser
        {
            public const int FirstNameMaxLength = 30;
            public const int FirstNameMinLength = 5;

            public const int LastNameMaxLength = 30;
            public const int LastNameMinLength = 5;
        }
        public class Dealer
        {
            public const int PhoneMaxLength = 13;
        }

        public class Category
        {
            public const int CategoryMaxLength = 12;
            public const int CategoryMinLength = 4;
        }

        public class EngineType
        {
            public const int EngineMaxLength = 10;
            public const int EngineMinLength = 3;
        }

        public class EuroStandard
        {
            public const int EuroStandardMaxLength = 8;
            public const int EuroStandardMinLength = 5;
        }

        public class Car
        {
            public const int CarMakeMaxLength = 12;
            public const int CarMakeMinLength = 3;

            public const int CarModelMaxLength = 12;
            public const int CarModelMinLength = 3;

            public const int MaxHorsePower = 1500;
            public const int MinHorsePower = 50;

            public const int MaxYearProduced = 2022;
            public const int MinYearProduced = 1886;

            public const int MaxCarMileage = 5000000;
            public const int MinCarMileage = 0;

            public const int ColorMaxLength = 23;
            public const int ColorMinLength = 3;

            public const int ImageURLMaxLength = 1000;
            public const int ImageURLMinLength = 10;

            public const int MinPrice = 100;
        }
    }
}
