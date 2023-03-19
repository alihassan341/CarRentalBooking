using Car_Rental_booking.Model;
using CarRentalBookingSystem.Data;
using CarRentalBookingSystem.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Razor.Language;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
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
                //return View();
                //return RedirectToAction("ClientLogin");
                return RedirectToAction(nameof(ClientProFile));

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
            if (client is null)
            {
                return View();
            }
                var LoginClient = await _context.Clients.Where(C =>
                C.Email == client.Email && C.Password == client.Password)
                .FirstOrDefaultAsync();
            if (LoginClient != null)
            {
                string message = LoginClient.FirstName + " " + LoginClient.LastName;

                return RedirectToAction(nameof(ClientProFile), new { message = message });
            }
            else
            {
                return NotFound("Oops!, something went wrong");
            }
                //Session["id"] = client.Id.ToString();
                //Session["UerName"] = client.Email.ToString();
            
            //return View();
        }

        public ActionResult ForGotpasword()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> ForGotpasword(Client client)
        {
            #region old code
            //if (client != null)
            //{
            //    if ((client.Age == 0 || client.PhoneNumber == 0 || client.Id == 0)
            //        && client.Email != null)
            //    {
            //        if (client.Password == null || client.Password == string.Empty)
            //        {
            //            var Password = await _context.Clients.Where(p => p.Email == client.Email && p.PetName == client.PetName).FirstOrDefaultAsync();

            //            if (Password == null)
            //            {
            //                return NotFound("Oops!, something went wrong");
            //            }
            //            else
            //            {
            //                //ForGotpasword Id = Password.T;
            //                //await _context.ForGotpaswords.AddAsync(Id);                            
            //                //return View();
            //                return RedirectToAction("Recoveryourpasswordbyemail", "Client", new { Client = Password });
            //            }
            //        }
            //        else
            //        {
            //            //var client1 = await _context.Clients.Where(p => p.Id ==client.Id).FirstOrDefaultAsync();                    
            //            //await _context.Clients.AddAsync(client1);
            //            var Client = await _context.Clients.FindAsync(id);
            //            Client.Password = client.Password;
            //            //await _context.Clients 

            //            return View();
            //        }
            //    }

            //    else
            //    {
            //        return View();
            //    }

            //}
            //else
            //{
            //    return View();
            //}
            #endregion
            if (client is null)
            {
                return NotFound("Oops!, something went wrong");
            }

            if ((client.Age == 0 || client.PhoneNumber == 0 || client.Id == 0)
                    && client.Email != null
                    && client.PetName != null)
            {
                var Password = await _context.Clients.Where(p => p.Email == client.Email && p.PetName == client.PetName).FirstOrDefaultAsync();

                if (Password is null)
                {
                    return NotFound("Oops!, something went wrong");
                }
                //return RedirectToAction("RecoverPas", new {Id = Password.Id});
                return RedirectToAction(nameof(Recoveryourpasswordbyemail), new { Id = Password.Id});

            } 

            return View();
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
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController));
        }


        public ActionResult Recoveryourpasswordbyemail(/*int Id*/)
        {
            //client.Password = string.Empty;
            //TempData["Id"] = Id;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Recoveryourpasswordbyemail(/*int Id,*/ Client client)
        {
            int Id = client.Id;
            var Password = await _context.Clients.Where(o => o.Id == Id).FirstOrDefaultAsync();
            //string? d = Password ? != null Password.Password.Password.ToString();

            if (Password is null)
            {
                return NotFound();
            }

            Password.Password = client.Password;
            _context.Update(Password);
            await _context.SaveChangesAsync();

            //return View();
            //return RedirectToAction("Index", "Home");
            return RedirectToAction(nameof(HomeController.Index), nameof(HomeController));
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