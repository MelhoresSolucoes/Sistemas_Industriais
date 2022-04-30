using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaIndustrial.Repositories.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(6,2)", precision: 6, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pecuarista",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pecuarista", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompraGado",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPecuarista = table.Column<int>(type: "INT", nullable: false),
                    DataEntrega = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompraGado", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompraGado_Pecuarista_IdPecuarista",
                        column: x => x.IdPecuarista,
                        principalTable: "Pecuarista",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompraGadoItem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCompraGado = table.Column<int>(type: "INT", nullable: false),
                    IdAnimal = table.Column<int>(type: "INT", nullable: false),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompraGadoItem", x => new { x.Id, x.IdAnimal, x.IdCompraGado });
                    table.ForeignKey(
                        name: "FK_CompraGadoItem_Animal_IdAnimal",
                        column: x => x.IdAnimal,
                        principalTable: "Animal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompraGadoItem_CompraGado_IdCompraGado",
                        column: x => x.IdCompraGado,
                        principalTable: "CompraGado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompraGado_IdPecuarista",
                table: "CompraGado",
                column: "IdPecuarista");

            migrationBuilder.CreateIndex(
                name: "IX_CompraGadoItem_IdAnimal",
                table: "CompraGadoItem",
                column: "IdAnimal");

            migrationBuilder.CreateIndex(
                name: "IX_CompraGadoItem_IdCompraGado",
                table: "CompraGadoItem",
                column: "IdCompraGado");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompraGadoItem");

            migrationBuilder.DropTable(
                name: "Animal");

            migrationBuilder.DropTable(
                name: "CompraGado");

            migrationBuilder.DropTable(
                name: "Pecuarista");
        }
    }
}
