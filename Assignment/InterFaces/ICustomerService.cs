using Assignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.InterFaces
{
    public interface ICustomerService
    {
        IEnumerable<Customer> GetAllCustomer();
        Customer GetCustomerById(int id);
        Customer AddCustomer(Customer customer);
        Customer UpdateCustomer(int id, Customer customer);
        void DeleteCustomer(int id);
    }
}
