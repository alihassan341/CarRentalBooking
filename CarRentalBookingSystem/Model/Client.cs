using System.ComponentModel.DataAnnotations;
using System.Security.Principal;

namespace Car_Rental_booking.Model
{
    public class Client : BaseDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public long PhoneNumber { get; set; }
        [Required]
        public long Age { get; set; }
        [Required]
        public string  Address { get; set; }
        [Required]
        public string PetName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        public string Password { get; set; }
        //Need to ask haroon bhai or sir subhan
        public ICollection<Booking>? Bookings { get; set; }
        public ICollection<Testimonial>? Testimonials { get; set; }

    }


}
