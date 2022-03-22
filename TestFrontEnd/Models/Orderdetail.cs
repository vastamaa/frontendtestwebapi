using System;
using System.Collections.Generic;

#nullable disable

namespace TestFrontEnd.Models
{
    public partial class Orderdetail
    {
        public int OrderNumber { get; set; }
        public string ProductCode { get; set; }
        public int QuantityOrdered { get; set; }
        public decimal PriceEach { get; set; }
        public short OrderLineNumber { get; set; }
    }
}
