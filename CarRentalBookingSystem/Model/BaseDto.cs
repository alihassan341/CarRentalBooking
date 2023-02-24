using System.ComponentModel.DataAnnotations;

namespace Car_Rental_booking.Model
{
    public class BaseDto
    {
        [Key]
        public int Id { get; set; }
    }
}
