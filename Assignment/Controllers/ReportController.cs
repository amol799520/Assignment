using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Assignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        [HttpGet("{StartDate}/{EndDate}")]
        public IEnumerable<SaleMobile> MobileSaleReportDatewise(DateTime startDate , DateTime endDate)
        {
            var entity = new List<SaleMobile>();
            using (AssignmentContext assignmentContext = new AssignmentContext())
            {
                List<Sale> sales = assignmentContext.Sale.Where(s => s.CraetedDate >= startDate && s.CraetedDate <= endDate).ToList();
                List<Mobile> mobiles = assignmentContext.Mobile.ToList();
                List<Customer> customers = assignmentContext.Customer.ToList();

                var data = from _sale in sales
                           join _mobile in mobiles on _sale.MobileId equals _mobile.Id
                           join _customer in customers on _sale.CustomerId equals _customer.CustId

                           select new
                           {
                               // id=  
                           };

                

            }
            return entity;
        }

        [HttpGet("{Month}")]
        public IEnumerable<SaleMobile> MobileSaleReportMonthWise(int month)
        {
            DateTime StartMonth = new DateTime(DateTime.Now.Year, month, 01);
            DateTime EndMonth = new DateTime(DateTime.Now.Year, month, System.DateTime.DaysInMonth(DateTime.Now.Year, month));
            var entity = new List<SaleMobile>();

            using (AssignmentContext assignmentContext = new AssignmentContext())
            {
                List<Sale> sales = assignmentContext.Sale.Where(s => s.CraetedDate >= StartMonth && s.CraetedDate <= EndMonth).ToList();
            }           
            return entity;
        }
    }
}
