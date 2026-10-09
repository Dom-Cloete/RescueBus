using domRescueBus.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace domRescueBus.Controllers
{
    public class HomeController : Controller
    {
        // retrieve driver and vehicle data from data repository and return to index page
        public ActionResult Index()
        {
            ViewBag.AllDrivers = DataRepository.GetDrivers();
            ViewBag.AllVehicles = DataRepository.GetVehicles();
            return View();
        }

        // return to history page
        public ActionResult History()
        {
            return View();
        }

        // retrieve service type, driver and vehicle data from data repository, populate viewModel and return to management page
        public ActionResult Management()
        {
            var viewModel = new ManagementViewModel
            {
                ServiceTypes = DataRepository.GetServiceTypes(),
                Drivers = DataRepository.GetInitialDrivers(),
                Vehicles = DataRepository.GetInitialVehicles()
            };
            return View(viewModel);
        }

        // export vehicle data as txt file
        public ActionResult ExportVehicles()
        {
            var vehicles = DataRepository.GetInitialVehicles();
            var serviceTypes = DataRepository.GetServiceTypes();

            var sb = new StringBuilder();
            sb.AppendLine("Vehicle ID,Type,Registration Number,Service Type");

            foreach (var vehicle in vehicles)
            {
                string serviceTypeName = serviceTypes.FirstOrDefault(s => s.Id == vehicle.ServiceId)?.Name ?? "Unknown Service";
                sb.AppendLine($"{vehicle.Id},{vehicle.Type},{vehicle.RegistrationNumber},{serviceTypeName}");
            }

            Response.AddHeader("Content-Disposition", "attachment; filename=Vehicles_Export_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt");
            return Content(sb.ToString(), "text/plain");
        }
    }
}