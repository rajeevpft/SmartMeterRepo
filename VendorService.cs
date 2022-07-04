using SmartMeterPro.Contract;
using SmartMeterPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMeterPro.Repository
{
    public class VendorService : IVendor
    {
        private readonly SMDBContext _dbContext;
        public VendorService(SMDBContext dbcontext)
        {
            _dbContext = dbcontext;
        }
        public void AddVendor(Vendors vendor)
        {
            _dbContext.vendors.Add(vendor);
            _dbContext.SaveChanges();
        }
        public Vendors GetVendorByMobNo(string mobNo)
        {
            return  _dbContext.vendors.Where(x => x.ContactNumber == mobNo).Select(y=>y).FirstOrDefault();
        }
        public void UpdateVendor(Vendors vendor)
        {
            Vendors v = (from x in _dbContext.vendors
                       where x.Id == vendor.Id
                       select x).FirstOrDefault();
            v.Address = vendor.Address;
            v.ContactNumber = vendor.ContactNumber;
            _dbContext.SaveChanges();
        }
    }
}
