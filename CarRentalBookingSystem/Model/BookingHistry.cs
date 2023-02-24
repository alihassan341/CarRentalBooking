using System.ComponentModel.DataAnnotations;

namespace Car_Rental_booking.Model
{
    public class BookingHistry  : BaseDto
    {
        [Required]
        public string Brand { get; set; }
        [Required]
        public string FleetName { get; set; }
        [Required]
        public int SeatingCapacity { get; set; }
        [Required]
        public string Model { get; set; }

        public DateTime BokingDatetime { get; set; } = DateTime.Now;
    }
}
