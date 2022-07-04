using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartMeterPro.Contract;
using SmartMeterPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMeterPro.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmartMeterController : ControllerBase
    {
        ISmartMeterRepository _repository;
        IVendor _vendor;
        public SmartMeterController(ISmartMeterRepository repo , IVendor vendor)
        {
            _repository = repo;
            _vendor = vendor;
        }
        [HttpPost("requestfornewconnection")]
        public async Task<ActionResult> RequestForNewConnection(Users user)
        {
            _repository.RequestForNewConnection(user);
            return Ok();
        }

        [HttpPost("addsmartmeter")]
        public async Task<ActionResult> AddSmartMeter(SmartMeter smartmeter)
        {
            _repository.AddSmartMeter(smartmeter);
            return Ok();
        }

        [HttpGet("getsmartmeterstatus")]
        public async Task<ActionResult> GetSmartMeterStatus(long smartMeterId)
        {
           return Ok( _repository.GetSmartMeterStatus(smartMeterId));
        }

        [HttpGet("getsmartmeterwithid")]
        public async Task<ActionResult> GetSmartMeterWithId(long smartMeterId)
        {
            return Ok(_repository.GetSmartMeterWithId(smartMeterId));
        }

        [HttpGet("getunusedsmartmeters")]
        public async Task<ActionResult> GetUnusedSmartMeters()
        {
           return Ok( _repository.GetUnusedSmartMeters());
        }

        [HttpPost("addvendor")]
        public async Task<ActionResult> AddVendor(Vendors vendor)
        {
            _vendor.AddVendor(vendor);
            return Ok();
        }
        [HttpGet("getvendorbymobno")]
        public async Task<ActionResult> GetVendorByMobNo(string mobNo)
        {
           return Ok( _vendor.GetVendorByMobNo(mobNo));
        }
        [HttpPut("updatevendor")]
        public async Task<ActionResult> UpdateVendor(Vendors vendor)
        {
            _vendor.UpdateVendor(vendor);
            return Ok();
        }
        [HttpPut("assignsmartmeter")]
        public async Task<ActionResult> AssignSmartMeter(Users user)
        {
           string AssignmentStatus = _repository.AssignSmartMeter(user);
            return Ok(AssignmentStatus);
        }
    }
}
