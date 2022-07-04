using SmartMeterPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMeterPro.Contract
{
    public interface IUsers
    {
        List<Users> GetAllUsers();
        string AddUser(Users user);
        string RequestForNewConnection(UserDetails userdetails);
        void AddUserLocation(UserLocations userLocation);
        void UpdateUser(Users user);
        Users GetUserByEmailId(string emailId);
        Users GetUserBySmartMeterId(long smartMeterId);
        IList<Users> GetAllUsersByAreaCode(long areaCode);
        void DeleteUserByEmailId(string emailId);
        IList<UserLocations> GetUserLocationByAreaCode(long areaCode);
    }
}
