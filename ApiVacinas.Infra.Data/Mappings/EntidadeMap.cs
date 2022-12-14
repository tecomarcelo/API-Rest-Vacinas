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
    public class EntidadeMap : IEntityTypeConfiguration<Entidade>
    {
        public void Configure(EntityTypeBuilder<Entidade> builder)
        {
            //nome da tabela
            builder.ToTable("ENTIDADE");

            //chave primaria
            builder.HasKey(e => e.IdEntidade);

            //mapeamento dos campos da tabela
            builder.Property(e => e.IdEntidade)
                .HasColumnName("IDENTIDADE")
                .IsRequired();

            builder.Property(e => e.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(e => e.Idade)
                .HasColumnName("IDADE")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(e => e.Cpf)
                .HasColumnName("CPF")
                .HasMaxLength(14)
                .IsRequired();

            builder.Property(e => e.DataInclusao)
                .HasColumnName("DATAINCLUSAO")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(e => e.DataAlteracao)
                .HasColumnName("DATAALTERACAO")
                .HasColumnType("datetime")
                .IsRequired();

            #region Mapeamento de campos únicos

            builder.HasIndex(e => e.Cpf)
                .IsUnique();

            #endregion
        }
    }
}
