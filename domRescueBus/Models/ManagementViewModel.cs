using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace domRescueBus.Models
{
    public class ManagementViewModel
    {
        public List<Driver> Drivers { get; set; }
        public List<Vehicle> Vehicles { get; set; }
        public List<ServiceType> ServiceTypes { get; set; }
    }
}