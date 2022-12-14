using ApiVacinas.Infra.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiVacinas.Infra.Data.Mappings
{
    /// <summary>
    /// Classe de mapeamento ORM para Entidade
    /// </summary>
    public class VacinaMap : IEntityTypeConfiguration<Vacina>
    {
        public void Configure(EntityTypeBuilder<Vacina> builder)
        {
            //nome da tabela
            builder.ToTable("VACINA");

            //chave primaria
            builder.HasKey(v => v.IdVacina);

            //mapeamento dos campos da tabela
            builder.Property(v => v.IdVacina)
                .HasColumnName("IDVACINA")
                .IsRequired();

            builder.Property(v => v.NomeVacina)
                .HasColumnName("NOMEVACINA")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(v => v.Lote)
                .HasColumnName("LOTE")
                .HasMaxLength(15)
                .IsRequired();

            builder.Property(v => v.DataInclusao)
                .HasColumnName("DATAINCLUSAO")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(v => v.DataAlteracao)
                .HasColumnName("DATAALTERACAO")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(v => v.IdEntidade)
                .HasColumnName("IDENTIDADE")
                .IsRequired();

            #region Mapeamento de relacionamento 1 para muitos

            builder.HasOne(v => v.Entidade) //Vacina TEM 1 Entidade(criança)
                .WithMany(e => e.Vacinas) //Entidade TEM MUITAS vacinas
                .HasForeignKey(v => v.IdEntidade); //chave estrangeira

            #endregion
        }
    }
}
