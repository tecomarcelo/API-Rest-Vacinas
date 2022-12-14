using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiVacinas.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CorrigeDataAlteracao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DATAALRERACAO",
                table: "ENTIDADE",
                newName: "DATAALTERACAO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DATAALTERACAO",
                table: "ENTIDADE",
                newName: "DATAALRERACAO");
        }
    }
}
