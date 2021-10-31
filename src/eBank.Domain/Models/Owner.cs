using System;
using System.Collections.Generic;
using System.Text;

namespace eBank.Domain.Models
{
    public class Owner : BaseEntity
    {
        public string OwnerName { get; set; }

        public string OwnerDocument { get; set; }

        public bool Active { get; set; }
    }
}
