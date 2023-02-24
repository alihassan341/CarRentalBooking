using System.ComponentModel.DataAnnotations;

namespace Car_Rental_booking.Model
{
    public class FleetMaster : BaseDto
    {
        [Required]
        public string FleetNumber { get; set; }
        [Required]
        public string FleetName { get; set; }

        [Required]
        public string FleetBrand { get; set; }
        [Required]
        public string Color { get; set; }
        [Required]
        public string FleetModel { get; set; }
        [Required]
        public sbyte FleetImage { get; set; }
        [Required]
        public string FleetCatgory { get; set; }
        public List<Booking> bookings { get; set; }


    }
}
