using Microsoft.EntityFrameworkCore;
using SmartMeterPro.Contract;
using SmartMeterPro.Enums;
using SmartMeterPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMeterPro.Repository
{
    public class SmartMeterRepository : ISmartMeterRepository
    {
        private readonly SMDBContext _dbContext;
        public SmartMeterRepository(SMDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public string AssignSmartMeter(Users user)
        {
            try
            {
                List<SmartMeter> smartMeters = GetActiveSmartMeter();
                if (smartMeters.Count() > 0 && smartMeters[0].Id != 0 && user.SmartMeterId == 0)
                {
                    Users u = (from x in _dbContext.users
                               where x.EmailAddress == user.EmailAddress
                               select x).FirstOrDefault();
                    u.SmartMeterId = smartMeters[0].Id;
                    _dbContext.SaveChanges();
                    UpdateSmartMeter(smartMeters[0]);
                    return ResponseMessage.METER_ASSIGNED.ToString();
                }
                string assignedStatus = user.SmartMeterId != 0 ? ResponseMessage.METER_ALREADY_ASSIGNED.ToString() : ResponseMessage.METER_NOT_AVAILABLE.ToString();
                return assignedStatus;
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        public void AddSmartMeter(SmartMeter meter)
        {
            if(meter !=null)
            {
                _dbContext.smartmeter.Add(meter);
                _dbContext.SaveChanges();
            }
        }
        public async Task<string> RequestForNewConnection(Users user)
        {

            if (user != null )
            {
                _dbContext.Add(user);
                await _dbContext.SaveChangesAsync();
                return user.FirstName + "Successfully Registered";
            }
            return "Invalid user";
        }
        public string GetSmartMeterStatus(long smartMeterId)
        {
            if(smartMeterId!=null)
            {
               return  _dbContext.smartmeter.Where(x=>x.Id== smartMeterId).Select(x => x.Status).FirstOrDefault();
            }
            return null;
        }

        public SmartMeter GetSmartMeterWithId(long smartMeterId)
        {
            SmartMeter smartMeter = new SmartMeter();
            if (smartMeterId != null)
            {
                smartMeter= _dbContext.smartmeter.Where(x => x.Id == smartMeterId).Select(y => y).FirstOrDefault();
            }
            return smartMeter;
        }

        public IList<SmartMeter> GetUnusedSmartMeters()
        {
          return  _dbContext.smartmeter.Where(x => x.Status == SmartMeterStatus.BURNED.ToString()).Select(y=>y).ToList();
        }

        public void UpdateSmartMeter(SmartMeter meter)
        {
            SmartMeter s = (from x in _dbContext.smartmeter
                       where x.Id == meter.Id
                       select x).FirstOrDefault();
            s.MeterState = MeterState.ASSIGNED.ToString();
            _dbContext.SaveChanges();
        }

        public List<SmartMeter> GetActiveSmartMeter()
        {
            List<SmartMeter> smartMeter = new List<SmartMeter>();
            smartMeter= _dbContext.smartmeter.Where(x => x.Status == SmartMeterStatus.ACTIVE.ToString()
            && x.MeterState==MeterState.UNASSIGNED.ToString()).Select(y => y).ToList();
            return smartMeter;
        }
    }
}
