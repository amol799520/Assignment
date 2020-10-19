using System;
using System.Collections.Generic;

namespace Assignment.Models
{
    public partial class Sale
    {
        public int Id { get; set; }
        public int? MobileId { get; set; }
        public int? Price { get; set; }
        public int? Discount { get; set; }
        public int? CustomerId { get; set; }
        public string PaymentType { get; set; }
        public DateTime? CraetedDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Mobile Mobile { get; set; }
    }
}
