using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaIndustrial.Repositories.Migrations
{
    public partial class ajustestotalizadores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "CompraGadoItem",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "CompraGado",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Total",
                table: "CompraGadoItem");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "CompraGado");
        }
    }
}
