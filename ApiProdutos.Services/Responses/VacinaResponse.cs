namespace ApiVacinas.Services.Responses
{
    /// <summary>
    /// Modelagem dos dados de retorno de vacinas na API
    /// </summary>
    public class VacinaResponse
    {
        public Guid IdVacina { get; set; }
        public string? NomeVacina { get; set; }
        public string? Lote { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataAlteracao { get; set; }

        #region Relacionamentos

        public EntidadeResponse Entidade { get; set; }

        #endregion
    }
}
