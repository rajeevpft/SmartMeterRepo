using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartMeterPro.Contract;
using SmartMeterPro.Enums;
using SmartMeterPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMeterPro.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComplaintsController : ControllerBase
    {
        IComplaint _repository;
        public ComplaintsController(IComplaint repo)
        {
            _repository = repo;
        }

        [HttpGet("getallcomplaintsbyemailid")]
        public async Task<ActionResult> GetAllComplaintsByEmailId(string emailId)
        {
           return Ok(_repository.GetAllComplaintsByEmailId(emailId));
        }
        [HttpPost("addcomplaint")]
        public async Task<ActionResult> AddComplaint(Complaints complaint)
        {
            return Ok(_repository.AddComplaint(complaint));
        }
        [HttpGet("getallcomplaintsbydate")]
        public async Task<ActionResult> GetAllComplaintsByDate(DateTime date)
        {
            return Ok(_repository.GetAllComplaintsByDate(date));
        }
        [HttpGet("getallcomplaintsbytype")]
        public async Task<ActionResult> GetAllComplaintsByType(ComplaintType type)
        {
            return Ok(_repository.GetAllComplaintsByType(type));
        }
        [HttpGet("getallresolvedcomplaints")]
        public async Task<ActionResult> GetAllResolvedComplaints()
        {
            return Ok( _repository.GetAllResolvedComplaints());
        }

        [HttpGet("getallunresolvedcomplaints")]
        public async Task<ActionResult> GetAllUnresolvedComplaints()
        {
           return Ok( _repository.GetAllUnresolvedComplaints());
        }

        [HttpGet("getcomplaintstatus")]
        public async Task<ActionResult> GetComplaintStatus(Guid complaintId)
        {
            return Ok( _repository.GetComplaintStatus(complaintId));
        }
        [HttpDelete("removecomplaintbyid")]
        public async Task<ActionResult> RemoveComplaintById(Guid complaintId)
        {
            _repository.RemoveComplaintById(complaintId);
            return Ok();
        }
        [HttpGet("updatecomplaint")]
        public async Task<ActionResult> UpdateComplaint(Complaints complaint)
        {
            _repository.UpdateComplaint(complaint);
            return Ok();
        }
    }
}
