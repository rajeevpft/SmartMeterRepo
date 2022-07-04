using SmartMeterPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMeterPro.Contract
{
   public interface ISmartMeterRepository
   {
        void AddSmartMeter(SmartMeter meter);
        void UpdateSmartMeter(SmartMeter meter);
        string GetSmartMeterStatus(long smartMeterId);
        IList<SmartMeter> GetUnusedSmartMeters();
        SmartMeter GetSmartMeterWithId(long smartMeterId);
        Task<string> RequestForNewConnection(Users user);
        string AssignSmartMeter(Users user);
    }
}
