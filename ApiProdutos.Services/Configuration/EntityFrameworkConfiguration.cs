using ApiVacinas.Infra.Data.Contexts;
using ApiVacinas.Infra.Data.Interfaces;
using ApiVacinas.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ApiVacinas.Services.Configuration
{
    /// <summary>
    /// Classe de configuração do EntityFramework
    /// </summary>
    public class EntityFrameworkConfiguration
    {
        /// <summary>
        /// configura o EntityFramework
        /// </summary>
        /// <param name="builder"></param>
        public static void AddEntityFramework(WebApplicationBuilder builder)
        {
            //capturar a string de conexão do banco de dados
            var connectionString = builder.Configuration.GetConnectionString("DBEXVacinas");

            //injetar a connectionstring na classe SqlServerContext do EntityFramework
            builder.Services.AddDbContext<SqlServerContext>
                (options => options.UseSqlServer(connectionString));

            //injeção de dependência para o UnitOfWork
            builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
