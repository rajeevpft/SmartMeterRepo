using SmartMeterPro.Contract;
using SmartMeterPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMeterPro.Repository
{
    public class LoginService : ILogin
    {
        private readonly SMDBContext _dbContext;
        public LoginService(SMDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Users GetUserByEmailAndPassword(string ConsumerEmailId, string password)
        {
            Users user = new Users();

            user = (from u in _dbContext.users
                    where u.EmailAddress == ConsumerEmailId
                    select u).FirstOrDefault();

            // user =  _dbContext.users.Find();
            return user;
        }
        public string  ValidatedUser(string emailId, string password)
        {
            Users user =  GetUserByEmailAndPassword(emailId, password);
            if (user != null && password != null)
            {
                if (user.EmailAddress == emailId && user.Password == password)
                {
                    return "valid user";
                }
                else
                {
                    return "Invalid user";
                }
            }
            return "Invalid user";
        }
    }
}
