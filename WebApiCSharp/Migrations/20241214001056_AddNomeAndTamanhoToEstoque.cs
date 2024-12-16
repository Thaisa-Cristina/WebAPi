using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApiCSharp.Migrations
{
    /// <inheritdoc />
    public partial class AddNomeAndTamanhoToEstoque : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "Estoque",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tamanho",
                table: "Estoque",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nome",
                table: "Estoque");

            migrationBuilder.DropColumn(
                name: "Tamanho",
                table: "Estoque");
        }
    }
}
