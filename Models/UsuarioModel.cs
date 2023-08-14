using ControleContatos.Enums;
using System.ComponentModel.DataAnnotations;

namespace ControleContatos.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do usuário")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Digite o login")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite o email")]
        [EmailAddress(ErrorMessage = "Digite um email válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite a senha")]
        public string Password { get; set; }
        public ProfileEnum Profile { get; set; }
        public DateTime Created { get; set; }
        public DateTime? LastUpdated { get; set; }
    }
}
