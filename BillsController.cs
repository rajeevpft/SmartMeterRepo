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
    public class BillsController : ControllerBase
    {
        IBills _repository;
        public BillsController(IBills billsRepo)
        {
            _repository = billsRepo;
        }
        [HttpGet("getbillsbyemailid")]
        public  List<Bills> GetBillsByEmailId(string emailId)
        {
            try
            {
                var repository =  _repository.GetBillsByEmailId(emailId);
                return repository;
            }
            catch (Exception ex)
            {
                return null; ;
            }
        }
        [HttpPost("addbills")]
        public async Task<ActionResult> AddBills(Bills bill)
        {
            _repository.AddBills(bill);
            return Ok();
        }
        [HttpDelete("deletebills")]
        public async Task<ActionResult> DeleteBills(int id)
        {
            _repository.DeleteBills(id);
            return Ok();
        }
        [HttpPut("updatebills")]
        public async Task<ActionResult> UpdateBills(Bills bills)
        {
            _repository.UpdateBills(bills);
            return Ok();
        }
    }
}
