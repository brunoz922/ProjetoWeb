using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcVendas.Migrations
{
    /// <inheritdoc />
    public partial class numeric6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Quantidade",
                table: "ItemsVenda",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "Quantidade",
                table: "ItemsCompra",
                type: "numeric",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Quantidade",
                table: "ItemsVenda",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "numeric");

            migrationBuilder.AlterColumn<int>(
                name: "Quantidade",
                table: "ItemsCompra",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "numeric");
        }
    }
}
