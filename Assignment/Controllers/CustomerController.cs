using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment.InterFaces;
using Assignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public readonly ICustomerService _CustomerService;

        public CustomerController(ICustomerService customerService)
        {
            _CustomerService = customerService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Customer>> GetAllCustomer()
        {
            try
            {
                var customers = _CustomerService.GetAllCustomer();
                return Ok(customers);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Customer> GetCustomerById(int id)
        {
            try
            {
                var customer = _CustomerService.GetCustomerById(id); ;
                if (customer == null)
                {
                    return NotFound();
                }           
                return Ok(customer);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult AddCustomer([FromBody] Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
             var item = _CustomerService.AddCustomer(customer);
            return CreatedAtAction("Get", new { id = item.CustId }, item);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateCustomer(int id, [FromBody] Customer customer)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var existingItem = _CustomerService.GetCustomerById(id);
                if (existingItem == null)
                {
                    return NotFound();
                }
                var item = _CustomerService.UpdateCustomer(id, customer);
                return CreatedAtAction("Get", new { id = item.CustId }, item);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteEmployee(int id)
        {
            try
            {
                var existingItem = _CustomerService.GetCustomerById(id);

                if(existingItem == null)
                {
                    return NotFound();
                }
                _CustomerService.DeleteCustomer(id);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
