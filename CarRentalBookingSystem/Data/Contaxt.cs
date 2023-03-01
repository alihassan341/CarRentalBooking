using Car_Rental_booking.Model;
using CarRentalBookingSystem.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CarRentalBookingSystem.Data
{
    public class Contaxt : DbContext
    {
        public Contaxt(DbContextOptions<Contaxt> options)
            : base(options)
        { }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<ForGotpasword> ForGotpaswords { get; set; }
        public DbSet<BookingHistry> BookingHistries { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ContactUs> contactUs { get; set; }
        public DbSet<FleetMaster> FleetMasters { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
    }

    //public class MyDbContextFactory : IDesignTimeDbContextFactory<Contaxt>
    //{
    //    public Contaxt CreateDbContext(string[] args)
    //    {
    //        var optionsBuilder = new DbContextOptionsBuilder<Contaxt>();
    //        optionsBuilder.UseSqlServer("DefaultConnection");

    //        return new Contaxt(optionsBuilder.Options);
    //    }
    //}
}


