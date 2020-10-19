using System;
using System.Collections.Generic;

namespace Assignment.Models
{
    public partial class Mobile
    {
        public Mobile()
        {
            Sale = new HashSet<Sale>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public int? ActualPrice { get; set; }
        public string ImeiNumber { get; set; }
        public DateTime? LauchDate { get; set; }
        public DateTime? CraetedDate { get; set; }
        public DateTime? UpatedDate { get; set; }

        public virtual ICollection<Sale> Sale { get; set; }
    }
}
