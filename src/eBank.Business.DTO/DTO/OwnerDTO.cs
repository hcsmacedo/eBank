using System.ComponentModel.DataAnnotations;

namespace eBank.Business.DTO.DTO
{
    public class OwnerDTO
    {
        [Required(ErrorMessage = "O campo 'Titular' é obrigatório.")]
        public string OwnerName { get; set; }

        [Required(ErrorMessage = "O campo 'Documento do Titular' é obrigatório.")]
        public string OwnerDocument { get; set; }

        [Required(ErrorMessage = "O campo 'Ativo' é obrigatório.")]
        public bool Active { get; set; }

    }
}
