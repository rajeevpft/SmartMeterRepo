using SmartMeterPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMeterPro.Contract
{
    public interface IBills
    {
        List<Bills> GetBillsByEmailId(string ConsumerEmailId);
        int AddBills(Bills bill);
        void DeleteBills(int Id);
        void UpdateBills(Bills post);
     
    }
}
