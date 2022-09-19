using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteFortes.Migrations
{
    public partial class Carga3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantidade",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "ValorTotal",
                table: "Pedido");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 9, 18, 20, 11, 17, 10, DateTimeKind.Local).AddTicks(8338),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 9, 18, 19, 52, 58, 766, DateTimeKind.Local).AddTicks(6379));

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "ProdutoId",
                keyValue: 1,
                column: "DataCadastro",
                value: new DateTime(2022, 9, 18, 20, 11, 17, 10, DateTimeKind.Local).AddTicks(8888));

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "ProdutoId",
                keyValue: 2,
                column: "DataCadastro",
                value: new DateTime(2022, 9, 18, 20, 11, 17, 10, DateTimeKind.Local).AddTicks(8894));

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "ProdutoId",
                keyValue: 3,
                column: "DataCadastro",
                value: new DateTime(2022, 9, 18, 20, 11, 17, 10, DateTimeKind.Local).AddTicks(8895));

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "ProdutoId",
                keyValue: 4,
                column: "DataCadastro",
                value: new DateTime(2022, 9, 18, 20, 11, 17, 10, DateTimeKind.Local).AddTicks(8897));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 9, 18, 19, 52, 58, 766, DateTimeKind.Local).AddTicks(6379),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 9, 18, 20, 11, 17, 10, DateTimeKind.Local).AddTicks(8338));

            migrationBuilder.AddColumn<int>(
                name: "Quantidade",
                table: "Pedido",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorTotal",
                table: "Pedido",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "ProdutoId",
                keyValue: 1,
                column: "DataCadastro",
                value: new DateTime(2022, 9, 18, 19, 52, 58, 766, DateTimeKind.Local).AddTicks(7379));

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "ProdutoId",
                keyValue: 2,
                column: "DataCadastro",
                value: new DateTime(2022, 9, 18, 19, 52, 58, 766, DateTimeKind.Local).AddTicks(7388));

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "ProdutoId",
                keyValue: 3,
                column: "DataCadastro",
                value: new DateTime(2022, 9, 18, 19, 52, 58, 766, DateTimeKind.Local).AddTicks(7390));

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "ProdutoId",
                keyValue: 4,
                column: "DataCadastro",
                value: new DateTime(2022, 9, 18, 19, 52, 58, 766, DateTimeKind.Local).AddTicks(7391));
        }
    }
}
