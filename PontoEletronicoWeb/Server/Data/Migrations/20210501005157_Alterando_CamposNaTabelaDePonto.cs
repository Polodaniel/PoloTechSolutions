using Microsoft.EntityFrameworkCore.Migrations;

namespace PontoEletronicoWeb.Server.Data.Migrations
{
    public partial class Alterando_CamposNaTabelaDePonto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DtaEscala",
                table: "FolhaPonto",
                newName: "DataRegistroPonto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataRegistroPonto",
                table: "FolhaPonto",
                newName: "DtaEscala");
        }
    }
}
