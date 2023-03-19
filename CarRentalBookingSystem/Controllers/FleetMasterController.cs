using Car_Rental_booking.Model;
using CarRentalBookingSystem.Data;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Hosting.Internal;
using System.IO;

namespace CarRentalBookingSystem.Controllers
{
    public class FleetMasterController : Controller
    {
        private readonly Contaxt _context;
        private readonly IWebHostEnvironment _hostEnviroment;

        public FleetMasterController(Contaxt context, IWebHostEnvironment hostEnvironment )
        {
            _context = context;        
            _hostEnviroment  = hostEnvironment;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Vehicles()
        {
            var List = _context.FleetMasters.ToList();
            return View(List);
        }

        public IActionResult VehicleAdd()
        {
            return  View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] 
        public async Task<ActionResult<FleetMaster>> VehicleAdd(FleetMaster fleetMaster, IFormFile? file)
        {
            //Need to ask haroon bhai or sir subhan
            //if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnviroment.WebRootPath;

             if (file != null)
             {
                    string filename = Guid.NewGuid().ToString();
                    string uplodes = Path.Combine(wwwRootPath, @"images\vehicle");
                    var extension = Path.GetExtension(file.FileName);

                using (var filestream = new FileStream(Path.Combine(uplodes,filename+extension),FileMode.Create))
                {
                    await file.CopyToAsync(filestream);

                        fleetMaster.FleetUrl = @"\images\vehicle" + filename + extension;
                }
             }

                //_context.Add(fleetMaster);
                await _context.FleetMasters.AddAsync(fleetMaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           }

            return View();
        }


        public IActionResult Cardetail()
        {
            return View ();
        }
    }
}
