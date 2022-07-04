using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMeterPro.Models
{
    public class Complaints
    {
        public string ConsumerEmailId { get; set; }
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Message { get; set; }
       
    }
}
