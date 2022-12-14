using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiVacinas.Infra.Data.Contexts
{
    public class SqlServerMigration : IDesignTimeDbContextFactory<SqlServerContext>
    {
        //metodo utilizado pelo Migrations para inicializar a classe
        //SqlServerContext utilizando os atributos do appsetings.json
        public SqlServerContext CreateDbContext(string[] args)
        {
            //lendo o arquivo appsettings.json
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            //capturar a connectionstring mapeaa dentro do arquivo
            var root = configurationBuilder.Build();
            var connectionString = root.GetSection("ConnectionStrings")
                .GetSection("DBEXVacinas").Value;

            //instanciar a classe SqlServerContext
            var builder = new DbContextOptionsBuilder<SqlServerContext>();
            builder.UseSqlServer(connectionString);

            return new SqlServerContext(builder.Options);
        }
    }
}
