using Microsoft.EntityFrameworkCore.Migrations;

namespace PontoEletronicoWeb.Server.Data.Migrations
{
    public partial class Add_ClienteId_Escala : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Escala",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Escala_ClienteId",
                table: "Escala",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Escala_Cliente_ClienteId",
                table: "Escala",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Escala_Cliente_ClienteId",
                table: "Escala");

            migrationBuilder.DropIndex(
                name: "IX_Escala_ClienteId",
                table: "Escala");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Escala");
        }
    }
}
