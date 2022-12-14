using System.ComponentModel.DataAnnotations;

namespace ApiVacinas.Services.Requests
{
    /// <summary>
    /// Modelagem da requisição da Entidade.
    /// </summary>
    public class EntidadePostRequest
    {
        [Required(ErrorMessage = "Informe o nome da criança.")]
        public string? Nome { get; set; }

        [Range(0, 5)]
        [Required(ErrorMessage = "Informe a idade da criança entre 0 e 5 anos.")]
        public int Idade { get; set; }

        [Required(ErrorMessage = "Informe o CPF da criança.")]
        public string? Cpf { get; set; }
    }
}
