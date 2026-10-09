using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace domRescueBus.Models
{
    public class Booking
    {
        public Guid BookingId { get; set; }
        public string ServiceType { get; set; }
        public string PatientFullName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime PickUpTime { get; set; }
        public DateTime DateOfBooking { get; set; }
        public string PickUpAddress { get; set; }
        public int DriverId { get; set; }
        public string DriverFullName { get; set; }
        public string DriverPhoneNumber { get; set; }
        public string DriverPicture { get; set; }
        public int VehicleId { get; set; }
        public string VehicleType { get; set; }
        public string VehicleRegistrationNumber { get; set; }
        public string VehiclePicture { get; set; }
        public bool IsSOS { get; set; }
    }
}