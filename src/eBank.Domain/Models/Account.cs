using System;
using System.Collections.Generic;
using System.Text;

namespace eBank.Domain.Models
{
    public class Account : BaseEntity
    {
        public int BankId { get; set; }

        public int BranchNumber { get; set; }

        public string AccountNumber { get; set; }
        
        public int OwnerId { get; set; }

        public bool Active { get; set; }

    }
}
