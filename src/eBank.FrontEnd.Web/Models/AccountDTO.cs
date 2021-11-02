
namespace eBank.FrontEnd.Web.Models
{
    public class AccountDTO
    {
        public int? Id { get; set; }
        
        public int BankId { get; set; }

        public string BranchNumber { get; set; }

        public string AccountNumber { get; set; }

        public int OwnerId { get; set; }

        public bool Active { get; set; }

        public BankDTO Bank { get; set; }

        public OwnerDTO Owner { get; set; }
    }
}
