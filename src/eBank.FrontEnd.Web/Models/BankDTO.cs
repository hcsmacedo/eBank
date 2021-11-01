using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBank.FrontEnd.Web.Models
{
    public class BankDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string BankCode { get; set; }
        public bool Active { get; set; }
    }
}
