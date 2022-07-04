using SmartMeterPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartMeterPro.Enums;

namespace SmartMeterPro.Contract
{
    public interface IComplaint
    {
        string AddComplaint(Complaints complaint);
        void UpdateComplaint(Complaints complaint);
        IList<Complaints> GetAllComplaintsByType(ComplaintType type);
        IList<Complaints> GetAllComplaintsByEmailId(string consumerEmailId);
        IList<Complaints> GetAllComplaintsByDate(DateTime date);
        IList<Complaints> GetAllUnresolvedComplaints();
        IList<Complaints> GetAllResolvedComplaints();
        string GetComplaintStatus(Guid complaintId);
        void RemoveComplaintById(Guid complaintId);
    }
}
