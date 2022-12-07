using CarMarket.Services.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CarMarket.Services.Constants.DataConstants.EngineType;

namespace CarMarket.Services.Data.Entities
{
    public  class EngineType
    {        
        public int Id { get; set; }

        [Required]
        [StringLength(EngineMaxLength, MinimumLength = EngineMinLength)]
        public string Name { get; set; }

        public virtual List<Car> Cars { get; set; } = new List<Car>();
    }
}
