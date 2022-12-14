using System.ComponentModel.DataAnnotations;

namespace ApiVacinas.Services.Requests
{
    /// <summary>
    /// Modelo de dados para a requisição de autenticação
    /// </summary>
    public class LoginPostRequest
    {
        [EmailAddress(ErrorMessage = "Informe um endereço de email válido.")]
        [Required(ErrorMessage = "Informe um Email de acesso.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a Senha de acesso.")]
        public string Senha { get; set; }
    }
}
