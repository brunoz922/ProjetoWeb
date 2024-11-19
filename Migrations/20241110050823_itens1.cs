using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcVendas.Migrations
{
    /// <inheritdoc />
    public partial class itens1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataVenda",
                table: "Compras",
                newName: "DataCompra");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataCompra",
                table: "Compras",
                newName: "DataVenda");
        }
    }
}
