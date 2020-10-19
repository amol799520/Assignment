using System;
using System.Collections.Generic;

namespace Assignment.Models
{
    public partial class Profit
    {
        public int Id { get; set; }
        public int? SaleId { get; set; }
        public int? ActualPrice { get; set; }
        public int? SelliingPrice { get; set; }
        public int? Profit1 { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
