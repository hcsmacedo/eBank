using System;

namespace eBank.Domain.Models
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            this.RegistrationDate = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
