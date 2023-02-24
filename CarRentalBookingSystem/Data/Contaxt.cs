using Car_Rental_booking.Model;
using Microsoft.EntityFrameworkCore;

namespace CarRentalBookingSystem.Data
{
    public class Contaxt : DbContext
    {
        public Contaxt(DbContextOptions<Contaxt> options)
            : base(options)
        { }

        public DbSet<Admin> Admins{ get; set; }
        public DbSet<Booking> Bookings { get; set; }
        //public DbSet<BaseDto> baseDtos { get; set; }
        public DbSet<BookingHistry> BookingHistries{ get; set; }
        public DbSet<Client> Clients{ get; set; }
        public DbSet<ContactUs> contactUs{ get; set; }
        public DbSet<FleetMaster> FleetMasters{ get; set; }
        public DbSet<Testimonial> Testimonials{ get; set; }
    }
}


