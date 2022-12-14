using System.ComponentModel.DataAnnotations;

namespace ApiVacinas.Services.Requests
{
    /// <summary>
    /// Modela da requisição do cadastro da Vacina
    /// </summary>
    public class VacinaPostRequest
    {
        [Required(ErrorMessage = "Informe o nome da vacina.")]
        public string? NomeVacina { get; set; }

        [Required(ErrorMessage = "Informe o Lote da vacina.")]
        public string? Lote { get; set; }

        [Required(ErrorMessage = "Informe o id da Entidade.")]
        public Guid IdEntidade { get; set; }
    }
}
