using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class User : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", nullable: false),
                    Email = table.Column<string>(type: "varchar(50)", nullable: false),
                    senha = table.Column<string>(type: "varchar(100)", nullable: false),
                    NúmerodeTelefone = table.Column<string>(name: "Número de Telefone", type: "varchar(100)", nullable: false),
                    BirthDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Validaçãodesenha = table.Column<string>(name: "Validação de senha", type: "varchar(100)", nullable: false),
                    Create = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2021, 12, 1, 14, 57, 49, 697, DateTimeKind.Local).AddTicks(4623)),
                    Update = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
