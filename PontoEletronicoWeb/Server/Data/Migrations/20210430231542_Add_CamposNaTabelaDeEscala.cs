using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PontoEletronicoWeb.Server.Data.Migrations
{
    public partial class Add_CamposNaTabelaDeEscala : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataEscala",
                table: "Escala",
                newName: "DataInicio");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataFim",
                table: "Escala",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataFim",
                table: "Escala");

            migrationBuilder.RenameColumn(
                name: "DataInicio",
                table: "Escala",
                newName: "DataEscala");
        }
    }
}
