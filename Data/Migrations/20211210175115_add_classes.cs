using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class add_classes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Create",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 10, 14, 51, 14, 654, DateTimeKind.Local).AddTicks(7661),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 1, 14, 57, 49, 697, DateTimeKind.Local).AddTicks(4623));

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdReceptor = table.Column<int>(type: "int", nullable: false),
                    IdUser1Id = table.Column<int>(type: "int", nullable: true),
                    IdEmissor = table.Column<int>(type: "int", nullable: false),
                    IdUser2Id = table.Column<int>(type: "int", nullable: true),
                    Mensagens = table.Column<string>(type: "VARCHAR(1000)", nullable: false),
                    Create = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Update = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chats_Users_IdUser1Id",
                        column: x => x.IdUser1Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chats_Users_IdUser2Id",
                        column: x => x.IdUser2Id,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Informacoes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Categoria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imagem = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Caminho = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Create = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Update = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Images = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Create = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Update = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comentario = table.Column<string>(type: "varchar(500)", nullable: true),
                    IdPost = table.Column<int>(type: "int", nullable: false),
                    IdPostagemId = table.Column<int>(type: "int", nullable: true),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdUsuárioId = table.Column<int>(type: "int", nullable: true),
                    Create = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Update = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comentarios_Posts_IdPostagemId",
                        column: x => x.IdPostagemId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comentarios_Users_IdUsuárioId",
                        column: x => x.IdUsuárioId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Deslikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPost = table.Column<int>(type: "int", nullable: false),
                    IdPostagemId = table.Column<int>(type: "int", nullable: true),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdUsuárioId = table.Column<int>(type: "int", nullable: true),
                    Create = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Update = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deslikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deslikes_Posts_IdPostagemId",
                        column: x => x.IdPostagemId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Deslikes_Users_IdUsuárioId",
                        column: x => x.IdUsuárioId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPost = table.Column<int>(type: "int", nullable: false),
                    IdPostagemId = table.Column<int>(type: "int", nullable: true),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdUsuárioId = table.Column<int>(type: "int", nullable: true),
                    Create = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Update = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Likes_Posts_IdPostagemId",
                        column: x => x.IdPostagemId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Likes_Users_IdUsuárioId",
                        column: x => x.IdUsuárioId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chats_IdUser1Id",
                table: "Chats",
                column: "IdUser1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_IdUser2Id",
                table: "Chats",
                column: "IdUser2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_IdPostagemId",
                table: "Comentarios",
                column: "IdPostagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_IdUsuárioId",
                table: "Comentarios",
                column: "IdUsuárioId");

            migrationBuilder.CreateIndex(
                name: "IX_Deslikes_IdPostagemId",
                table: "Deslikes",
                column: "IdPostagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Deslikes_IdUsuárioId",
                table: "Deslikes",
                column: "IdUsuárioId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_IdPostagemId",
                table: "Likes",
                column: "IdPostagemId");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_IdUsuárioId",
                table: "Likes",
                column: "IdUsuárioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "Deslikes");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Create",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2021, 12, 1, 14, 57, 49, 697, DateTimeKind.Local).AddTicks(4623),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2021, 12, 10, 14, 51, 14, 654, DateTimeKind.Local).AddTicks(7661));
        }
    }
}
