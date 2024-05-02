using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AsianFlix.Migrations
{
    /// <inheritdoc />
    public partial class alteracaoCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DtCadastro",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Cliente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DtCadastro",
                table: "Cliente",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "Cliente",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
