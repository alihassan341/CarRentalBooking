using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Car_Rental_booking.Model
{
    public class Booking : BaseDto
    {
        public int? FleetMasterId { get; set; }
        public int? ClientId { get; set; }
        public DateTime BookingDate { get; set; } = DateTime.Now;

        public string Status { get; set; }
        [ValidateNever]
        public FleetMaster FleetMaster { get; set; }
        [ValidateNever]
        public Client Client { get; set; }

    }
}
