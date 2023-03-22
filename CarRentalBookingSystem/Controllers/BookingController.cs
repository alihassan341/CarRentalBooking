using CarRentalBookingSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRentalBookingSystem.Controllers
{
    public class BookingController : Controller
    {
        private readonly Contaxt _context;

        public BookingController()
        {
             
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Booking()
        {
            //var List = _context.Bookings.ToListAsync();
            return View();
        }

        public IActionResult BookingHistary()
        {
            return View();
        }
    }
}
