using System.ComponentModel.DataAnnotations;

namespace Loja.Application.Contracts.Requests
{
    public class ClienteUpdateRequest
    {
        [Required]
        public int Id { get; set; }

        public string Cpf { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
