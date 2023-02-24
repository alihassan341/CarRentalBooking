namespace Car_Rental_booking.Model
{
    public class Testimonial : BaseDto
    {
        public int? ClientId { get; set; }
        public Client Client { get; set; }

        public string Remark { get; set; }

    }
}
