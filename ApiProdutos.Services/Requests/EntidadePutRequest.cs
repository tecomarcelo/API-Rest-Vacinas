using System.ComponentModel.DataAnnotations;

namespace ApiVacinas.Services.Requests
{
    /// <summary>
    /// Modelagem da requisição para edição da entidade
    /// </summary>
    public class EntidadePutRequest
    {
        [Required(ErrorMessage = "Informe o Id da Entidade.")]
        public Guid IdEntidade { get; set; }

        [Required(ErrorMessage = "Informe o nome da criança.")]
        public string? Nome { get; set; }

        [Range(0, 5)]
        [Required(ErrorMessage = "Informe a idade da criança entre 0 e 5 anos.")]
        public int Idade { get; set; }

        [Required(ErrorMessage = "Informe o CPF da criança.")]
        public string? Cpf { get; set; }
    }
}
