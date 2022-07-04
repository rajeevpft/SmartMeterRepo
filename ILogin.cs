using SmartMeterPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMeterPro.Contract
{
    public interface ILogin
    {
        string ValidatedUser(string emailId , string password);
        Users GetUserByEmailAndPassword(string EmailId , string password);
    }
}
