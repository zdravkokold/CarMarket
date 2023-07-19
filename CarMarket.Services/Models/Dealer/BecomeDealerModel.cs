using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMarket.Services.Models.Dealer
{
    public class BecomeDealerModel
    {
        [StringLength(15, MinimumLength = 7)]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}
