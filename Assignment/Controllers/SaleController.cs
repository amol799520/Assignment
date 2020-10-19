using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Assignment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        [HttpGet]

        public IEnumerable<Sale> GetAllSoldMobile()
        {
            using (AssignmentContext assignmentContext = new AssignmentContext())
            {
                return assignmentContext.Sale.ToList();
            }
        }

        [HttpPost]
        public void SaleNewMobile([FromBody] Sale sale)
        {
            using (AssignmentContext assignmentContext = new AssignmentContext())
            {
                assignmentContext.Sale.Add(sale);
                assignmentContext.SaveChanges();
            }
        }
    }
}
