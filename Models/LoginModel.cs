using System.ComponentModel.DataAnnotations;

namespace ControleContatos.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "O campo Login é obrigatório")]
        public string Login { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório")]
        public string Password { get; set; }
    }
}
