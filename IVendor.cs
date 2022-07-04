using SmartMeterPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMeterPro.Contract
{
    public interface IVendor
    {
        void AddVendor(Vendors vendor);
        void UpdateVendor(Vendors vendor);
        Vendors GetVendorByMobNo(string mobNo);
    }
}
