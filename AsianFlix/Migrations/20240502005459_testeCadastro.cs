﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AsianFlix.Migrations
{
    /// <inheritdoc />
    public partial class testeCadastro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cadastrar",
                columns: table => new
                {
                    CadastrarID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClienteName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    FormaPagamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordConfirmation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cadastrar", x => x.CadastrarID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cadastrar");
        }
    }
}
