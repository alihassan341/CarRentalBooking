using Car_Rental_booking.Model;
using CarRentalBookingSystem.Data;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace CarRentalBookingSystem.Controllers
{
//    [Route("api/[controller]")]
//    [ApiController]
    public class ContactUSController : Controller
    {

        private readonly Contaxt _context;        

        public ContactUSController(Contaxt context)
        {
            _context = context;
         
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult PostContactUs()
        {
            return View();
        }

            [HttpPost]
            public async Task<ActionResult<ContactUs>> PostContactUs(ContactUs? Contactus)
            {
            if (Contactus == null)
            {
                Contactus.Email = "basit@gmail.com";
                Contactus.Subject = "Some info";
                Contactus.Name = "Basit Khan";
                Contactus.Message = "Info";
            }

            if (ModelState.IsValid == true)
                {
                    _context.contactUs.Add(Contactus);
                    await _context.SaveChangesAsync();
                    ViewData["OkStatus"] = "your request successfully sended";
                    return View();
                }
             return BadRequest(ModelState);
            }
    }
}
