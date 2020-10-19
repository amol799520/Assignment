using Assignment.InterFaces;
using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Services
{
    public class MobileService : IMobileService
    {
        public Mobile AddMobile(Mobile mobile)
        {
            try
            {
                using (AssignmentContext assignmentContext = new AssignmentContext())
                {
                    assignmentContext.Mobile.Add(mobile);
                    assignmentContext.SaveChanges();
                    return mobile;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Mobile> GetAllMobile()
        {
            try
            {
                using (AssignmentContext assignmentContext = new AssignmentContext())
                {
                    return assignmentContext.Mobile.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Mobile GetMobileById(int id)
        {
            try
            {
                using (AssignmentContext assignmentContext = new AssignmentContext())
                {
                    return assignmentContext.Mobile.Where(mob => mob.Id == id).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteMobile(int id)
        {
            try
            {
                using (AssignmentContext assignmentContext = new AssignmentContext())
                {
                    var entity = assignmentContext.Mobile.Where(mob => mob.Id == id).FirstOrDefault();
                    if (entity != null)
                    {
                        assignmentContext.Mobile.Remove(entity);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Mobile UpdateMobile(int id, Mobile mobile)
        {
            using (AssignmentContext assignmentContext = new AssignmentContext())
            {
                var entity = assignmentContext.Mobile.Where(mob => mob.Id == id).FirstOrDefault();
                if (entity != null)
                {
                    entity.Name = mobile.Name;
                    entity.ImeiNumber = mobile.ImeiNumber;
                    entity.CompanyName = mobile.CompanyName;
                    entity.Description = mobile.Description;
                    entity.ActualPrice = mobile.ActualPrice;
                    entity.LauchDate = mobile.LauchDate;
                    entity.UpatedDate = System.DateTime.Now;
                    assignmentContext.SaveChanges();
                }
            }
            return mobile;
        }
    }
}
