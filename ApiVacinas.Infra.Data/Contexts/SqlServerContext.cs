using ApiVacinas.Infra.Data.Entities;
using ApiVacinas.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiVacinas.Infra.Data.Contexts
{
    /// <summary>
    /// Classe de configuração(contexto) do EntityFramework no produto Infra.Data
    /// </summary>
    public class SqlServerContext : DbContext
    {
        //contrutor para injeção de dependência
        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options)
        {

        }

        //sobrescrever o método OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //informar cada classe de mapeamento do projeto
            modelBuilder.ApplyConfiguration(new EntidadeMap());
            modelBuilder.ApplyConfiguration(new VacinaMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }

        //declaraa uma propriedade DbSet para cada entidade
        public DbSet<Entidade> Entidade { get; set; }
        public DbSet<Vacina> Vacina { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
