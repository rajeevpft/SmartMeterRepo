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
    public class LoginController : ControllerBase
    {
        ILogin _repository;
        public LoginController(ILogin repo)
        {
            _repository = repo;
        }
        [HttpPost("validateusers")]
        public  string ValidateUsers(string emailId, string  password)
        {
            try
            {
                return   _repository.ValidatedUser(emailId, password);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet("getuserbyemailandpassword")]
        public async Task<ActionResult> GetUserByEmailAndPassword(string emailId, string password)
        {
            try
            {
                return Ok(_repository.GetUserByEmailAndPassword(emailId, password));
               
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
