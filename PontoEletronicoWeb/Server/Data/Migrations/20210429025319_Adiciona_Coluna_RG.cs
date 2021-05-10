using Microsoft.EntityFrameworkCore.Migrations;

namespace PontoEletronicoWeb.Server.Data.Migrations
{
    public partial class Adiciona_Coluna_RG : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Rg",
                table: "Funcionario",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rg",
                table: "Funcionario");
        }
    }
}
