using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace domRescueBus.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string RegistrationNumber { get; set; }
        public string Picture { get; set; }
        [Display(Name = "Service Type")]
        public int ServiceId { get; set; }
    }
}