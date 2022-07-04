using SmartMeterPro.Contract;
using SmartMeterPro.Enums;
using SmartMeterPro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartMeterPro.Repository
{
    public class ComplaintRepository : IComplaint
    {
        private readonly SMDBContext _dbContext;
        public ComplaintRepository(SMDBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public string AddComplaint(Complaints complaint)
        {
            try
            {
                Guid id = Guid.NewGuid();
                complaint.Id = id;
                _dbContext.complaints.Add(complaint);
                _dbContext.SaveChanges();
                return ResponseMessage.COMPLAINT_RAISED.ToString();
            }
            catch(Exception ex)
            {
                return ResponseMessage.COMPLAINT_FAILED.ToString();
            }
        }

        public IList<Complaints> GetAllComplaintsByEmailId(string EmailId)
        {
            if (_dbContext != null)
            {
               return _dbContext.complaints.Where(x => x.ConsumerEmailId == EmailId).Select(y => y).ToList();
            }
            return null;
        }

        public IList<Complaints> GetAllComplaintsByDate(DateTime date)
        {
            if (_dbContext != null)
            {
              return  _dbContext.complaints.Where(x => x.Date == date).Select(y => y).ToList();
            }
            return null;
        }

        public IList<Complaints> GetAllComplaintsByType(ComplaintType type)
        {
            if (_dbContext != null)
            {
                return _dbContext.complaints.Where(x => x.Type == type.ToString()).Select(y => y).ToList();
            }
            return null;
        }

        public IList<Complaints> GetAllResolvedComplaints()
        {
            if (_dbContext != null)
            {
                return _dbContext.complaints.Where(x => x.Status== ComplaintStatus.RESOLVED.ToString()).Select(y => y).ToList();
            }
            return null;
        }

        public IList<Complaints> GetAllUnresolvedComplaints()
        {
            if (_dbContext != null)
            {
                return _dbContext.complaints.Where(x => x.Status != ComplaintStatus.RESOLVED.ToString()).Select(y => y).ToList();
            }
            return null;
        }

        public string GetComplaintStatus(Guid complaintId)
        {
            if (_dbContext != null)
            {
               return  _dbContext.complaints.Where(x => x.Id== complaintId).Select(y => y.Status).FirstOrDefault();
            }
            return null;
        }
        public void RemoveComplaintById(Guid complaintId)
        {
            if (_dbContext != null && complaintId !=null)
            {
                Complaints complaints = new Complaints();
                complaints = _dbContext.complaints.Where(x => x.Id == complaintId).Select(y=>y).FirstOrDefault();
                _dbContext.complaints.Attach(complaints);
                _dbContext.complaints.Remove(complaints);
                _dbContext.SaveChanges();
            }
        }
        public void UpdateComplaint(Complaints complaint)
        {
            Complaints c = (from x in _dbContext.complaints
                          where x.ConsumerEmailId == complaint.ConsumerEmailId
                            select x).FirstOrDefault();
            _dbContext.SaveChanges();
        }
    }
}
