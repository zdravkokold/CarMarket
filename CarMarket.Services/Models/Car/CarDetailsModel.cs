﻿using CarMarket.Services.Models.Dealer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMarket.Services.Models.Car
{
    public class CarDetailsModel : CarModel
    {
        public DealerModel Dealer { get; set; }

        public string Category { get; set; } = null!;

        public string EngineType { get; set; } = null!;

        public string EuroStandard { get; set; } = null!;
    }
}
