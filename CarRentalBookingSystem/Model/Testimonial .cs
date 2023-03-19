using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Car_Rental_booking.Model
{
    public class Testimonial : BaseDto
    {
        public int? ClientId { get; set; }
        [ValidateNever]
        public Client Client { get; set; }

        public string Remark { get; set; }

    }
}
