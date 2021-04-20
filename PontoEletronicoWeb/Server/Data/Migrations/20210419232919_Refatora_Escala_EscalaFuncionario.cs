using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PontoEletronicoWeb.Server.Data.Migrations
{
    public partial class Refatora_Escala_EscalaFuncionario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Escala_Funcionario_FuncionarioId",
                table: "Escala");

            migrationBuilder.DropIndex(
                name: "IX_Escala_FuncionarioId",
                table: "Escala");

            migrationBuilder.DropColumn(
                name: "FuncionarioId",
                table: "Escala");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataEscala",
                table: "Escala",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "EscalaFuncionario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FuncionarioId = table.Column<int>(type: "int", nullable: false),
                    EscalaId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    DtaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EscalaFuncionario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EscalaFuncionario_Escala_EscalaId",
                        column: x => x.EscalaId,
                        principalTable: "Escala",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EscalaFuncionario_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EscalaFuncionario_EscalaId",
                table: "EscalaFuncionario",
                column: "EscalaId");

            migrationBuilder.CreateIndex(
                name: "IX_EscalaFuncionario_FuncionarioId",
                table: "EscalaFuncionario",
                column: "FuncionarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EscalaFuncionario");

            migrationBuilder.DropColumn(
                name: "DataEscala",
                table: "Escala");

            migrationBuilder.AddColumn<int>(
                name: "FuncionarioId",
                table: "Escala",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Escala_FuncionarioId",
                table: "Escala",
                column: "FuncionarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Escala_Funcionario_FuncionarioId",
                table: "Escala",
                column: "FuncionarioId",
                principalTable: "Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
