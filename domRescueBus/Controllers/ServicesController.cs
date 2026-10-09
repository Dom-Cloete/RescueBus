using domRescueBus.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace domRescueBus.Controllers
{
    public class ServicesController : Controller
    {
        // return to select service page
        public ActionResult SelectService()
        {
            return View();
        }

        // get service type by id
        private string GetServiceTypeById(int id)
        {
            switch (id)
            {
                case 1: return "Advanced Life Support";
                case 2: return "Basic Life Support";
                case 3: return "Patient Support";
                case 4: return "Medical Utility Vehicle";
                case 5: return "Event Medical Ambulance";
                case 6: return "Air Ambulance";
                default: return "Unknown";
            }
        }

        // retrieves info to display in booking form -> populate viewModel and return to make booking page
        [HttpGet]
        public ActionResult MakeBooking(int serviceId)
        {
            var viewModel = new BookingFormViewModel
            {
                Drivers = DataRepository.GetDrivers(),
                Vehicles = DataRepository.GetVehicles(),
                ServiceType = GetServiceTypeById(serviceId),
                ServiceTypeId = serviceId
            };
            return View(viewModel);
        }

        // sends info to display in booking form -> redirect to booking confirmed
        [HttpPost]
        public ActionResult MakeBooking(Booking booking)
        {
            if (booking.BookingId == Guid.Empty)
            {
                booking.BookingId = Guid.NewGuid();
            }
            booking.DateOfBooking = DateTime.Now;

            string jsonFilePath = Server.MapPath("~/App_Data/Bookings.json");

            DataRepository.SaveBooking(booking, jsonFilePath);

            return RedirectToAction("BookingConfirmed", new { id = booking.BookingId });

        }

        // filter drivers and vehicles based on service selected
        public ActionResult GetDriversAndVehiclesByService(int serviceId)
        {
            var drivers = DataRepository.GetDrivers()
                .Where(d => d.ServiceId == serviceId)
                .Select(d => new { d.Id, d.Name });

            var vehicles = DataRepository.GetVehicles()
                .Where(v => v.ServiceId == serviceId)
                .Select(v => new { v.Id, v.Type });

            var driverNames = drivers.Select(d => d.Name).ToList();
            var driverIds = drivers.Select(d => d.Id).ToList();

            var vehicleTypes = vehicles.Select(v => v.Type).ToList();
            var vehicleIds = vehicles.Select(v => v.Id).ToList();

            string response = string.Format(
                "{0};{1};{2};{3}",
                string.Join(",", driverNames),
                string.Join(",", driverIds),
                string.Join(",", vehicleTypes),
                string.Join(",", vehicleIds)
            );

            return Content(response, "text/plain");
        }

        // display booking confirmed page
        public ActionResult BookingConfirmed(string id)
        {
            ViewData["BookingIdFromUrl"] = id;

            return View();
        }

        // display ride history page
        public ActionResult RideHistory()
        {
            string path = Server.MapPath("~/App_Data/Bookings.json");

            if (!System.IO.File.Exists(path))
            {
                ViewBag.Bookings = new List<dynamic>();
            }
            else
            {
                string bookingsJson = System.IO.File.ReadAllText(path);
                ViewBag.Bookings = JsonConvert.DeserializeObject<List<dynamic>>(bookingsJson) ?? new List<dynamic>();
            }

            return View();
        }
    }
}