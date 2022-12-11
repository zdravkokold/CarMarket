using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMarket.Services.Models.Car
{
    public class CarsQueryModel : CarModel
    {
        public int TotalCarsCount { get; set; }

        public IEnumerable<CarModel> Cars { get; set; } = new List<CarModel>();
    }
}
