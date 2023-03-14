using Car_Rental_booking.Model;
using CarRentalBookingSystem.Data;
using CarRentalBookingSystem.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net;
using System.Runtime.CompilerServices;

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
            

            if (ModelState.IsValid)
            {
                var LoginClient = await _context.Clients.Where(C =>
            C.Email == client.Email && C.Password == client.Password)
                .FirstOrDefaultAsync();
                string message = LoginClient.FirstName + " " + LoginClient.LastName;
                //Session["id"] = client.Id.ToString();
                //Session["UerName"] = client.Email.ToString();
                return RedirectToAction("ClientProFile", "Client", new { message = message });
            }
            else
            {
                //ModelState.AddModelError("Email And Password IS reqrid");
                return NotFound();
            }
            return View();
            
        }

        public ActionResult ForGotpasword()
        {
            return View();
        }
            [HttpPost]
        public async Task<ActionResult> ForGotpasword(Client client,int? id)
        {
            if (client != null)
             {
                if ((client.Age == 0 || client.PhoneNumber == 0 || client.Id == 0)
                    && client.Email != null)
                {
                    if (client.Password == null || client.Password == string.Empty)
                    {
                        var Password = await _context.Clients.Where(p => p.Email == client.Email && p.PetName == client.PetName).FirstOrDefaultAsync();

                        if (Password == null)
                        {
                            return NotFound("Oops!, something went wrong");
                        }
                        else
                        {
                            //ForGotpasword Id = Password.T;
                            //await _context.ForGotpaswords.AddAsync(Id);
                            TempData["Id"] = Password.Id;
                            //return View();
                            return RedirectToAction("Recoveryourpasswordbyemail", "Client");
                        }
                    }
                    else
                    {
                        //var client1 = await _context.Clients.Where(p => p.Id ==client.Id).FirstOrDefaultAsync();                    
                        //await _context.Clients.AddAsync(client1);
                        var Client = await _context.Clients.FindAsync(id);
                        Client.Password = client.Password;
                        //await _context.Clients 

                        return View();
                    }
                }
               
                else
                {
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


        public ActionResult Recoveryourpasswordbyemail()
        {
            //var model = new Client();
            //model.Id = Id;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Recoveryourpasswordbyemail(Client client)
        {
            int id = 13;
            var Password = await _context.Clients.Where(o => o.Id == id).FirstOrDefaultAsync();
            //string? d = Password ? != null Password.Password.Password.ToString();


            Password.Password = client.Password;
            _context.Update(Password);
            await _context.SaveChangesAsync();

            //return View();
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