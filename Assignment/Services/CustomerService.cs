using Assignment.InterFaces;
using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Services
{
    public class CustomerService : ICustomerService
    {
        public Customer AddCustomer(Customer customer)
        {
            try
            {
                using (AssignmentContext assignmentContext = new AssignmentContext())
                {
                    assignmentContext.Customer.Add(customer);
                    assignmentContext.SaveChanges();
                    return customer;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void DeleteCustomer(int id)
        {
            try
            {
                using (AssignmentContext assignmentContext = new AssignmentContext())
                {
                    var entity = assignmentContext.Customer.Where(cust => cust.CustId == id).FirstOrDefault();
                    if (entity != null)
                    {
                        assignmentContext.Customer.Remove(entity);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Customer> GetAllCustomer()
        {
            try
            {
                using (AssignmentContext assignmentContext = new AssignmentContext())
                {
                    return assignmentContext.Customer.ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Customer GetCustomerById(int id)
        {
            try
            {
                using (AssignmentContext assignmentContext = new AssignmentContext())
                {
                    return assignmentContext.Customer.Where(cust => cust.CustId == id).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Customer UpdateCustomer(int id, Customer customer)
        {
            using (AssignmentContext assignmentContext = new AssignmentContext())
            {
                var entity = assignmentContext.Customer.Where(mob => mob.CustId == id).FirstOrDefault();
                if (entity != null)
                {
                    entity.CustName = customer.CustName;
                    entity.CustMobiile= customer.CustMobiile;
                    entity.CustEmailId = customer.CustEmailId;
                    entity.CustAddress = customer.CustAddress;                    
                    entity.UpatedDate = System.DateTime.Now;
                    assignmentContext.SaveChanges();
                }
            }
            return customer;
        }
    }
}
