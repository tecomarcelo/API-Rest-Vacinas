// <auto-generated />
using System;
using ApiVacinas.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiVacinas.Infra.Data.Migrations
{
    [DbContext(typeof(SqlServerContext))]
    [Migration("20221117194234_AddUsuario")]
    partial class AddUsuario
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ApiVacinas.Infra.Data.Entities.Entidade", b =>
                {
                    b.Property<Guid>("IdEntidade")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IDENTIDADE");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("nvarchar(14)")
                        .HasColumnName("CPF");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("date")
                        .HasColumnName("DATAALRERACAO");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("date")
                        .HasColumnName("DATAINCLUSAO");

                    b.Property<int>("Idade")
                        .HasColumnType("int")
                        .HasColumnName("IDADE");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("NOME");

                    b.HasKey("IdEntidade");

                    b.HasIndex("Cpf")
                        .IsUnique();

                    b.ToTable("ENTIDADE", (string)null);
                });

            modelBuilder.Entity("ApiVacinas.Infra.Data.Entities.Usuario", b =>
                {
                    b.Property<Guid>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("datetime")
                        .HasColumnName("DATAINCLUSAO");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("EMAIL");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("NOME");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("SENHA");

                    b.HasKey("IdUsuario");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("USUARIO", (string)null);
                });

            modelBuilder.Entity("ApiVacinas.Infra.Data.Entities.Vacina", b =>
                {
                    b.Property<Guid>("IdVacina")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IDVACINA");

                    b.Property<DateTime>("DataAlteracao")
                        .HasColumnType("date")
                        .HasColumnName("DATAALTERACAO");

                    b.Property<DateTime>("DataInclusao")
                        .HasColumnType("date")
                        .HasColumnName("DATAINCLUSAO");

                    b.Property<Guid>("IdEntidade")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IDENTIDADE");

                    b.Property<string>("Lote")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasColumnName("LOTE");

                    b.Property<string>("NomeVacina")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("NOMEVACINA");

                    b.HasKey("IdVacina");

                    b.HasIndex("IdEntidade");

                    b.ToTable("VACINA", (string)null);
                });

            modelBuilder.Entity("ApiVacinas.Infra.Data.Entities.Vacina", b =>
                {
                    b.HasOne("ApiVacinas.Infra.Data.Entities.Entidade", "Entidade")
                        .WithMany("Vacinas")
                        .HasForeignKey("IdEntidade")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Entidade");
                });

            modelBuilder.Entity("ApiVacinas.Infra.Data.Entities.Entidade", b =>
                {
                    b.Navigation("Vacinas");
                });
#pragma warning restore 612, 618
        }
    }
}
