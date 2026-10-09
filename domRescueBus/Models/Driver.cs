using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace domRescueBus.Models
{
    public class Driver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Picture { get; set; }
        [Display(Name = "Service Type")]
        public int ServiceId { get; set; }
    }
}