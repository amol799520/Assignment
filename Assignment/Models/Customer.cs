using System;
using System.Collections.Generic;

namespace Assignment.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Sale = new HashSet<Sale>();
        }

        public int CustId { get; set; }
        public string CustName { get; set; }
        public string CustMobiile { get; set; }
        public string CustEmailId { get; set; }
        public string CustAddress { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpatedDate { get; set; }

        public virtual ICollection<Sale> Sale { get; set; }
    }
}
