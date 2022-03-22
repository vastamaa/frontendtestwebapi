﻿using System;
using System.Collections.Generic;

#nullable disable

namespace TestFrontEnd.Models
{
    public partial class Office
    {
        public string OfficeCode { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Territory { get; set; }
    }
}
