using CarMarket.Services.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CarMarket.Services.Constants.DataConstants.Category;

namespace CarMarket.Services.Data.Entities
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(CategoryMaxLength, MinimumLength = CategoryMinLength)]
        public string Name { get; set; }

        public virtual List<Car> Cars { get; set; } = new List<Car>();
    }
}
