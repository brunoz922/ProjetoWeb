using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcVendas.Migrations
{
    /// <inheritdoc />
    public partial class itemvenda466 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "Recursos",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "NFSaidas",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "Impostos",
                table: "NFSaidas",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "NFEntradas",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "Impostos",
                table: "NFEntradas",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "Custos",
                table: "Manutencoes",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "ItemsVenda",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "ItemsCompra",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "Salario",
                table: "Funcionarios",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "REAL",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Hectares",
                table: "Fazendas",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "REAL");

            migrationBuilder.AlterColumn<decimal>(
                name: "Hectares",
                table: "AreasPlantio",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "REAL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "Recursos",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "NFSaidas",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<decimal>(
                name: "Impostos",
                table: "NFSaidas",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<decimal>(
                name: "Total",
                table: "NFEntradas",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<decimal>(
                name: "Impostos",
                table: "NFEntradas",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<decimal>(
                name: "Custos",
                table: "Manutencoes",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "ItemsVenda",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<decimal>(
                name: "Preco",
                table: "ItemsCompra",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<decimal>(
                name: "Salario",
                table: "Funcionarios",
                type: "REAL",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Hectares",
                table: "Fazendas",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<decimal>(
                name: "Hectares",
                table: "AreasPlantio",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");
        }
    }
}
