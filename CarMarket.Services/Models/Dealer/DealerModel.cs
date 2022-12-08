using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMarket.Services.Models.Dealer
{
    public class DealerModel
    {
        public string PhoneNumber { get; set; } = null!;

        public string? Email { get; set; } = null;

    }
}
