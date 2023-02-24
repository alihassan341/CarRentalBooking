using System.ComponentModel.DataAnnotations;

namespace Car_Rental_booking.Model
{
    public class ContactUs : BaseDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public string Subject { get; set; }
    }
}
