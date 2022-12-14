namespace ApiVacinas.Services.Responses
{
    /// <summary>
    /// Modelagem de dados de retorno de empresa na API
    /// </summary>
    public class EntidadeResponse
    {
        public Guid IdEntidade { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Cpf { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
