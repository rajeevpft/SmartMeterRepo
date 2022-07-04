using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMeterPro.Models
{
    public class SmartMeter
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public long MeterPrice { get; set; }
        public int VendorId { get; set; }
        public DateTime ? PurchaseDate { get; set; }
        public string MeterState { get; set; }
    }
}
