using System.ComponentModel.DataAnnotations;

namespace eBank.Business.DTO.DTO
{
    public class AccountDTO
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "O campo 'Banco' é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "Banco inválido.")]
        public int BankId { get; set; }

        [Required(ErrorMessage = "O campo 'Número da Agência' é obrigatório.")]
        public string BranchNumber { get; set; }

        [Required(ErrorMessage = "O campo 'Número da Conta' é obrigatório.")]
        public string AccountNumber { get; set; }

        [Required(ErrorMessage = "O campo 'Titular' é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "Titular inválido.")]
        public int OwnerId { get; set; }

        [Required(ErrorMessage = "O campo 'Ativo' é obrigatório.")]
        public bool Active { get; set; }
    }
}
