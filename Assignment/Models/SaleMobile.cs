using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment.Models
{
    public class SaleMobile
    {
        public int Id { get; set; }
        public Customer customer { get; set; }
        public Sale sale { get; set; }

    }
}
