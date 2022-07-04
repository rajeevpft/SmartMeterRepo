using Microsoft.EntityFrameworkCore;
using SmartMeterPro.Contract;
using SmartMeterPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMeterPro.Repository
{
    public class BillsRepository : IBills
    {
        private readonly SMDBContext _dbContext;
        public BillsRepository(SMDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int  AddBills(Bills bill)
        {
            _dbContext.bills.Add(bill);
            _dbContext.SaveChanges();
            return bill.Id;
        }

        public void DeleteBills(int id)
        {
            Bills b = (from x in _dbContext.bills
                       where x.Id == id
                       select x).FirstOrDefault();
            _dbContext.bills.Attach(b);
            _dbContext.bills.Remove(b);
            _dbContext.SaveChanges();
        }

        public  List<Bills> GetBillsByEmailId(string emailId)
        {
            if (_dbContext != null)
            {
                return _dbContext.bills.Where(x => x.ConsumerEmailId == emailId).Select(y => y).ToList();
            }
            return null;
        }

        public void  UpdateBills(Bills bills)
        {
            Bills b = (from x in _dbContext.bills
                            where x.ConsumerEmailId == bills.ConsumerEmailId
                            select x).FirstOrDefault();
            b.BillingAmount = bills.BillingAmount;
            b.BillUnits = bills.BillUnits;
            b.Date = bills.Date;
            _dbContext.SaveChanges();
        }
    }
}
