using Car_Rental_booking.Model;
using CarRentalBookingSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarRentalBookingSystem.Controllers
{
    public class FleetMasterController : Controller
    {
        private readonly Contaxt _Contaxt;
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Vehicles()
        {
            var List = _Contaxt.FleetMasters.ToList();
            return View(List);
        }

        public IActionResult VehicleAdd()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<FleetMaster>> VehicleAdd(FleetMaster Master)
        {
            if (ModelState.IsValid)
            {
                if (Master != null)
                {
                    _Contaxt.FleetMasters.Add(Master);
                    await _Contaxt.SaveChangesAsync();
                    return View();

                }
            }
            return View();
        }

        public IActionResult Cardetail()
        {
            return View ();
        }
    }
}
