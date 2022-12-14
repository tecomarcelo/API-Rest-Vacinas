using System.ComponentModel.DataAnnotations;

namespace ApiVacinas.Services.Requests
{
    /// <summary>
    /// Modelagem da requisição de cadasto de Usuário
    /// </summary>
    public class RegisterPostRequest
    {
        [Required(ErrorMessage = "Informe o nome do usuário.")]
        public string Nome { get; set; }

        [EmailAddress(ErrorMessage = "Informe um email válido.")]
        [Required(ErrorMessage = "Informe o email do usuário.")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [StringLength(15, MinimumLength = 8, ErrorMessage = "A senha deve ter entre {2} e {1} caracteres")]
        [Required(ErrorMessage = "Informe a senha do usuário.")]
        public string Senha { get; set; }

        [Compare("Senha", ErrorMessage = "As senhas não conferem.")]
        public string SenhaConfirma { get; set; }

    }
}
