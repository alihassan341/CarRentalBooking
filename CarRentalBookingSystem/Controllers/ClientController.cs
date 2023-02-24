using Car_Rental_booking.Model;
using CarRentalBookingSystem.Data;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CarRentalBookingSystem.Controllers
{
//    [ApiController]
//    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        private readonly Contaxt _context;

        public ClientController(Contaxt context)
        {
            _context = context;
        }
        [HttpGet]
        //[ActionName]
        public IActionResult Index()
        {
            IEnumerable<Client> Clients = _context.Clients;

            return View(Clients);
        }
        [HttpGet]
        //[ActionName("Register")]
        public IActionResult Create()

        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Client client)
        {
            if (ModelState.IsValid == true)
            {
                _context.Clients.Add(client);
                _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
