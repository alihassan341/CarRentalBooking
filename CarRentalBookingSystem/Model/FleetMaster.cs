using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using ServiceStack.DataAnnotations;
//using System.ComponentModel.DataAnnotations;

namespace Car_Rental_booking.Model
{
    public class FleetMaster : BaseDto
    {
        [Required]
        [Unique]
        public string FleetNumber { get; set; }
        [Required]
        public string FleetName { get; set; }

        [Required]
        public string FleetBrand { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string FleetModel { get; set; }
        
        public string FleetUrl { get; set; }
        [Required]
        public string FleetCatgory { get; set; }
        [ValidateNever]
        public ICollection<Booking>? bookings { get; set; }


    }
}
