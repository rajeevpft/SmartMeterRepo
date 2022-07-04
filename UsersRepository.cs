using SmartMeterPro.Contract;
using SmartMeterPro.Enums;
using SmartMeterPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMeterPro.Repository
{
    public class UsersRepository : IUsers
    {
        private readonly SMDBContext _dbContext;
        public UsersRepository(SMDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public string AddUser(Users user)
        {
            _dbContext.users.Add(user);
            _dbContext.SaveChanges();
            return ResponseMessage.USER_SUCCESSFULLY_REGISTERED.ToString();
        }
        public string RequestForNewConnection(UserDetails userdetails)
        {
            try
            {
                Users validUser = GetUserByEmailId(userdetails.user.EmailAddress);
                if (validUser != null)
                {
                    _dbContext.userlocation.Add(userdetails.userlocations);
                     UpdateUser(userdetails.user);
                    _dbContext.SaveChanges();
                    return ResponseMessage.USER_SUCCESSFULLY_REGISTERED.ToString();
                }
                else if(!String.IsNullOrEmpty(validUser.EmailAddress))
                {
                    return ResponseMessage.INVALID_USER.ToString();
                }
                return ResponseMessage.ALREADY_RESISTERED.ToString();
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
        public void AddUserLocation(UserLocations userLocation)
        {
            _dbContext.userlocation.Add(userLocation);
            _dbContext.SaveChanges();
        }
       
        public void DeleteUserByEmailId(string emailId)
        {
            Users u = (from x in _dbContext.users
                       where x.EmailAddress == emailId
                       select x).FirstOrDefault();
            _dbContext.users.Attach(u);
            _dbContext.users.Remove(u);
            _dbContext.SaveChanges();
        }
        public IList<UserLocations> GetUserLocationByAreaCode(long areaCode)
        {
            return _dbContext.userlocation.Where(x => x.AreaCode == areaCode).ToList();
        }
        public List<Users> GetAllUsers()
        {
            var userlst = _dbContext.users.ToList();
            return userlst;
        }
        public IList<Users> GetAllUsersByAreaCode(long areaCode)
        {
            return _dbContext.users.Where(x => x.AreaCode == areaCode).Select(y => y).ToList();
        }
        public Users GetUserByEmailId(string emailId)
        {
            return _dbContext.users.Where(x => x.EmailAddress == emailId).Select(y => y).FirstOrDefault();
        }
        public Users GetUserBySmartMeterId(long smartMeterId)
        {
            return _dbContext.users.Where(x => x.SmartMeterId == smartMeterId).Select(y => y).FirstOrDefault();
        }
        public void UpdateUser(Users user)
        {
            Users c = (from x in _dbContext.users
                       where x.EmailAddress == user.EmailAddress
                       select x).FirstOrDefault();
            c.AreaCode = user.AreaCode;
            c.Status = user.Status;
            _dbContext.SaveChanges();
        }
        public List<SmartMeter> GetActiveSmartMeter()
        {
            return _dbContext.smartmeter.Where(x => x.Status == SmartMeterStatus.ACTIVE.ToString() && x.MeterState == MeterState.UNASSIGNED.ToString()).Select(y => y).ToList();
        }
        //public Users ValidateEmailId(string emailId)
        //{
        //    _dbContext
        //}

        public void GetUsersDetails(Users user)
        {
            SmartMeter smartmeter = new SmartMeter();

            Users c = (from x in _dbContext.users
                       join s in _dbContext.smartmeter
                       on x.SmartMeterId equals s.Id
                       where x.EmailAddress == user.EmailAddress
                       select x).FirstOrDefault();
            c.AreaCode = user.AreaCode;
            c.Status = user.Status;
            _dbContext.SaveChanges();
        }
    }
}
