using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMeterPro.Models
{
    public class Bills
    {
        [Key]
        public int Id { get; set; }
        public string ConsumerEmailId { get; set; }
        public DateTime Date { get; set; }
        public int SmartMeterId { get; set; }
        public double BillUnits { get; set; }
        public double BillingAmount { get; set; }
    }
}
