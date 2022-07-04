using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMeterPro.Models
{
    public class UserLocations
    {
        [Key]
        public long AreaCode { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string  State { get; set; }
        public string Pincode { get; set; }
    }
}
