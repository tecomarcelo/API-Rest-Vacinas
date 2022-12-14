using System.ComponentModel.DataAnnotations;

namespace ApiVacinas.Services.Requests
{
    /// <summary>
    /// Modelagem da requisição para edição da vacina
    /// </summary>
    public class VacinaPutRequest
    {
        [Required(ErrorMessage = "Informe o Id da Vacina.")]
        public Guid IdVacina { get; set; }

        [Required(ErrorMessage = "Informe o nome da vacina.")]
        public string? NomeVacina { get; set; }

        [Required(ErrorMessage = "Informe o Lote da vacina.")]
        public string? Lote { get; set; }

        [Required(ErrorMessage = "Informe o Id da Entidade.")]
        public Guid IdEntidade { get; set; }
    }
}
