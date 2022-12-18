using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CarMarket.Services.Constants.DataConstants.Dealer;


namespace CarMarket.Services.Data.Entities

{
    public class Dealer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(PhoneMaxLength)]
        [Phone]
        public string PhoneNumber { get; set; } 

        [Required]
        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public virtual ApplicationUser User { get; set; } 
    }
}
