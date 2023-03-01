using Car_Rental_booking.Model;
using CarRentalBookingSystem.Data;
using CarRentalBookingSystem.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.EntityFrameworkCore;
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
            public async Task<ActionResult<Client>> Create(Client client)
            {
                if (ModelState.IsValid == true)
                {
                    _context.Clients.Add(client);
                    await _context.SaveChangesAsync();
                    return View();

                }
                return BadRequest(ModelState);
            }
        public IActionResult ClientLogin()
        {
            return View();
        }
        [HttpPost]
        //Route[("ClientLogin")]
        public async Task<ActionResult> ClientLogin(Client client)
        {
            var LoginClient = await _context.Clients.Where(C => 
            C.Email == client.Email && C.Password == client.Password)
                .FirstOrDefaultAsync();

            if (LoginClient == null) 
            {
               return NotFound(); 
            }
            
            string message = LoginClient.FirstName+ " " + LoginClient.LastName;
            //Session["id"] = client.Id.ToString();
            //Session["UerName"] = client.Email.ToString();
            return  RedirectToAction("ClientProFile", "Client", new { message = message });
        }

        public async Task<ActionResult> ForGotpasword(Client client)
        {
            if (client.Password == null || client.Password == string.Empty)
            {
                var  Password = await _context.Clients.Where(p => p.Email == client.Email && p.PetName == client.PetName).FirstOrDefaultAsync();

                if (Password == null)
                {
                    return NotFound("Something went wrong");
                }
                else
                {
                    //ForGotpasword Id = Password.T;
                    //await _context.ForGotpaswords.AddAsync(Id);
                    return View();
                }
            }
            else
            {
                return View();
            }
        }


        public ActionResult ClientProFile(string message)
        {
            ViewData["OK"] = message;

            //if (Session["id"] == null)
            //{
            //    return RedirectToAction("login");
            //}
            //else
            //{
            //    return View();
            //}
            return View();
        }

        
       public ActionResult Logout()
        {
            //Session.Abandon();
            return RedirectToAction("Index", "Home");
        }




        //[HttpDelete("{id}")]
        //public async Task<ActionResult<Client>> DeleteCity(int id)
        //{
        //    var Client = await _context.Clients.FindAsync(id);
        //    if (Client == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Clients.Remove(Client);
        //    await _context.SaveChangesAsync();

        //    return Client;
        //}
    }
}
