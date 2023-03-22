using Car_Rental_booking.Model;
using CarRentalBookingSystem.Data;
using CarRentalBookingSystem.Models;
using Castle.Core.Resource;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Diagnostics;

namespace CarRentalBookingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Contaxt _context;

        public HomeController(ILogger<HomeController> logger, Contaxt context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            //var FleetMasters = _context.FleetMasters.ToList();
            //var contactUs = _context.contactUs.ToList();

            //var viewModelList = new List<Tuple<FleetMaster, ContactUs>>();

            ////foreach (var Masters in FleetMasters)
            ////{
            ////    var contactU = contactUs.FirstOrDefault(o => o.CustomerId == customer.Id);

            ////    if (contactU != null)
            ////    {
            ////        var viewModel = new Tuple<FleetMaster, ContactUs>(Masters, contactU);
            ////        viewModelList.Add(viewModel);
            ////    }
            ////}

            //return View(viewModelList);

            var list = _context.FleetMasters.ToList();
            return View(list);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AboutUS()
        {
            return View();
        }

        
        public IActionResult service()
        {
            return View();
        }

        public IActionResult category()
        {
            
            return View(_context.FleetMasters.ToList());
        }

        public IActionResult CarDetail()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}