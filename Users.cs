using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMeterPro.Models
{
    public class Users
    {
        public int ID { get; set; }
        public string Role { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public long AreaCode { get; set; }
        public string MobileNumber { get; set; }
        public string LanguageSelected { get; set; }
        public int SmartMeterId { get; set; }
        public string Status { get; set; }
    }
}
