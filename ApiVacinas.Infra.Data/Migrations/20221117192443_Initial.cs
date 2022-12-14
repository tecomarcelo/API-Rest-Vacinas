using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiVacinas.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ENTIDADE",
                columns: table => new
                {
                    IDENTIDADE = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    IDADE = table.Column<int>(type: "int", nullable: false),
                    CPF = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    DATAINCLUSAO = table.Column<DateTime>(type: "date", nullable: false),
                    DATAALRERACAO = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENTIDADE", x => x.IDENTIDADE);
                });

            migrationBuilder.CreateTable(
                name: "VACINA",
                columns: table => new
                {
                    IDVACINA = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOMEVACINA = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    LOTE = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    DATAINCLUSAO = table.Column<DateTime>(type: "date", nullable: false),
                    DATAALTERACAO = table.Column<DateTime>(type: "date", nullable: false),
                    IDENTIDADE = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VACINA", x => x.IDVACINA);
                    table.ForeignKey(
                        name: "FK_VACINA_ENTIDADE_IDENTIDADE",
                        column: x => x.IDENTIDADE,
                        principalTable: "ENTIDADE",
                        principalColumn: "IDENTIDADE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ENTIDADE_CPF",
                table: "ENTIDADE",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VACINA_IDENTIDADE",
                table: "VACINA",
                column: "IDENTIDADE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VACINA");

            migrationBuilder.DropTable(
                name: "ENTIDADE");
        }
    }
}
