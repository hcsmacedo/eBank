using System;
using System.Collections.Generic;
using System.Text;

namespace eBank.Domain.Models
{
    public class Bank : BaseEntity
    {
        public string Name { get; set; }
        public string BankCode { get; set; }
        public bool Active { get; set; }
    }
}
