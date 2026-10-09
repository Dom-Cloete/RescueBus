using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace domRescueBus.Models
{
    public class BookingFormViewModel
    {
        public string ServiceType { get; set; }
        public int ServiceTypeId { get; set; }
        public string PatientName { get; set; }
        public string ContactNumber { get; set; }
        public DateTime PickUpTime { get; set; }
        public string Reason { get; set; }
        public string PickUpAddress { get; set; }
        public int SelectedDriverId { get; set; }
        public int SelectedVehicleId { get; set; }
        public List<Driver> Drivers { get; set; }
        public List<Vehicle> Vehicles { get; set; }
    }
}