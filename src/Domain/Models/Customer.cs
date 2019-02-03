﻿using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public partial class Customer : BaseModel
    {
        public Customer()
        {
            Invoice = new HashSet<Invoice>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public int? SupportRepId { get; set; }

        public virtual Employee SupportRep { get; set; }
        public virtual ICollection<Invoice> Invoice { get; set; }
    }
}
