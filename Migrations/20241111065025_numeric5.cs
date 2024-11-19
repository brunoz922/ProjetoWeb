using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcVendas.Migrations
{
    /// <inheritdoc />
    public partial class numeric5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "Recursos",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "ItemsVenda",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "real");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "ItemsCompra",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "real");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "Recursos",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "ItemsVenda",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "ItemsCompra",
                type: "real",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "numeric");
        }
    }
}
