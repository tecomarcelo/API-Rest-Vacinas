namespace ApiVacinas.Services.Configuration
{
    /// <summary>
    /// Classe de configuração do AutoMapper
    /// </summary>
    public class AutoMapperConfiguration
    {
        /// <summary>
        /// Metodo para configuração de uso do AutoMapper
        /// </summary>
        /// <param name="builder"></param>
        public static void AddAutoMapper(WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
