using Car_Rental_booking.Model;
using CarRentalBookingSystem.Data;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CarRentalBookingSystem.Controllers
{
    //[ApiController]
    //[Route("api/[controller]")]
    public class ClientController : Controller
    {
        private readonly Contaxt _context;

        public ClientController(Contaxt context)
        {
            _context = context;
        }
        [HttpGet]           
        public IActionResult Index()
        {
            IEnumerable<Client> Clients = _context.Clients;

            return View(Clients);
        }
        [HttpGet]
        public IActionResult Create()

        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
       
            public async Task<ActionResult<Client>> Create(Client? client)
            {
                if (ModelState.IsValid == true)
                {
                _context.Clients.Add(client);
                _context.SaveChangesAsync();
                return View();

            }
            return BadRequest(ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Client>> DeleteCity(int id)
        {
            var Client = await _context.Clients.FindAsync(id);
            if (Client == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(Client);
            await _context.SaveChangesAsync();

            return Client;
        }
    }
}
