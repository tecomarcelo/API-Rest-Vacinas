namespace ApiVacinas.Services.Authorization
{
    /// <summary>
    /// Modelo de dados do conteudo do TOKEN
    /// </summary>
    public class JwtSettings
    {
        /// <summary>
        /// Chave secreta antifalsificação do Token
        /// </summary>
        public string SecretyKey { get; set; }

        /// <summary>
        /// Tempo de expiração em horas
        /// </summary>
        public int ExpirationInHours { get; set; }
    }
}
