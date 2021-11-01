using System.ComponentModel.DataAnnotations;

namespace eBank.Business.DTO.DTO
{
    public class BankDTO
    {
        public int? Id { get; set; }
        [Required(ErrorMessage = "O campo 'Nome' é obrigatório.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O campo 'Código do Banco' é obrigatório.")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "O código do banco deve ser formado por 3 dígitos.")]
        public string BankCode { get; set; }
        [Required(ErrorMessage = "O campo 'Ativo' é obrigatório.")]
        public bool Active { get; set; }
    }
}
