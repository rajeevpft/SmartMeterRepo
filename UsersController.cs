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
    public class UsersController : ControllerBase
    {
        IUsers _repository;
        public UsersController(IUsers repository)
        {
            _repository = repository;
        }

        [HttpPost("adduser")]
        public string AddUser(Users user)
        {
            return _repository.AddUser(user);
        }
        [HttpGet("getusers")]
        public List<Users>  GetAllUsers()
        {
            return _repository.GetAllUsers();
        }
        [HttpGet("getuserlocationbyarea")]
        public async Task<ActionResult> GetUserLocationByArea(long areacode)
        {
            return Ok(_repository.GetUserLocationByAreaCode(areacode));
        }
        [HttpPost("requestfornewconnection")]
        public string RequestForNewConnection( UserDetails userdetails)
        {
            return _repository.RequestForNewConnection(userdetails);
        }
        [HttpPost("adduserloaction")]
        public async Task<ActionResult> AddUserLocation(UserLocations userlocation)
        {
            _repository.AddUserLocation(userlocation);
            return Ok();
        }
       
        [HttpGet("getallusersbyareacode")]
        public async Task<ActionResult> GetAllUsersByAreaCode(long areacode)
        {
            return Ok(_repository.GetAllUsersByAreaCode(areacode));
        }
        [HttpGet("getuserbyemailid")]
        public async Task<ActionResult> GetUserByEmailId(string emailId)
        {
            return Ok(_repository.GetUserByEmailId(emailId));
        }
        [HttpGet("getuserbysmartmeterid")]
        public async Task<ActionResult> GetUserBySmartMeterId(long smartmeterId)
        {
            return Ok(_repository.GetUserBySmartMeterId(smartmeterId));
        }
        [HttpPut("updateuser")]
        public async Task<ActionResult> UpdateUser(Users user)
        {
            _repository.UpdateUser(user);
            return Ok();
        }

        [HttpDelete("deleteuserbyemailid")]
        public async Task<ActionResult> DeleteUserByEmailId(string emaild)
        {
            _repository.DeleteUserByEmailId(emaild);
            return Ok();
        }

        
    }
}
