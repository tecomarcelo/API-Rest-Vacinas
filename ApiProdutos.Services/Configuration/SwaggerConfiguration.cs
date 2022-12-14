using Microsoft.OpenApi.Models;

namespace ApiVacinas.Services.Configuration
{
    /// <summary>
    /// Classe para configuração da documentação do Swagger
    /// </summary>
    public class SwaggerConfiguration
    {
        /// <summary>
        /// Configurar o conteudo da ducumentação do Swagger
        /// </summary>
        /// <param name="builder"></param>
        public static void AddSwagger(WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API para controle de Vacinas",
                    Description = "Projeto desenvolvido em NET6 API com EntityFramework SqlServer",
                    Contact = new OpenApiContact
                    {
                        Name = "Rede de Vacinas INDORTESTE",
                        Url = new Uri("http://www.indorteste.com.br"),
                        Email = "tecomarcelo@hotmail.com"
                    }
                });
                    
            });
        }
    }
}
