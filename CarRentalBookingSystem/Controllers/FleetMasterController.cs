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

        public FleetMasterController(Contaxt context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnviroment = hostEnvironment;

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
            return View(_context.FleetMasters);
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

                    if(fleetMaster.FleetUrl != null)
                    {
                        var oldImagepath = Path.Combine(wwwRootPath, fleetMaster.FleetUrl.TrimStart('\\'));
                        if(System.IO.File.Exists(oldImagepath)) 
                        {
                            System.IO.File.Delete(oldImagepath);
                        }
                    }

                    using (var filestream = new FileStream(Path.Combine(uplodes, filename + extension), FileMode.Create))
                    {
                        await file.CopyToAsync(filestream);

                        fleetMaster.FleetUrl = @"\images\vehicle\" + filename + extension;
                    }
                }
                if(fleetMaster.Id is 0)
                {
                    await _context.FleetMasters.AddAsync(fleetMaster);
                }
                else
                {
                     _context.FleetMasters.Update(fleetMaster);
                }                
                
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            
        }

        public IActionResult Cardetail()
        {
            return View();
        }
    }
}
