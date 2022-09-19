using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TesteFortes.Migrations
{
    public partial class Carga2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                oldDefaultValue: new DateTime(2022, 9, 18, 12, 47, 55, 526, DateTimeKind.Local).AddTicks(9225));

            migrationBuilder.AddColumn<int>(
                name: "PedidoId1",
                table: "ItensPedido",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedido_PedidoId1",
                table: "ItensPedido",
                column: "PedidoId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ItensPedido_Pedido_PedidoId1",
                table: "ItensPedido",
                column: "PedidoId1",
                principalTable: "Pedido",
                principalColumn: "PedidoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItensPedido_Pedido_PedidoId1",
                table: "ItensPedido");

            migrationBuilder.DropIndex(
                name: "IX_ItensPedido_PedidoId1",
                table: "ItensPedido");

            migrationBuilder.DropColumn(
                name: "PedidoId1",
                table: "ItensPedido");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2022, 9, 18, 12, 47, 55, 526, DateTimeKind.Local).AddTicks(9225),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2022, 9, 18, 19, 52, 58, 766, DateTimeKind.Local).AddTicks(6379));

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "ProdutoId",
                keyValue: 1,
                column: "DataCadastro",
                value: new DateTime(2022, 9, 18, 12, 47, 55, 526, DateTimeKind.Local).AddTicks(9858));

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "ProdutoId",
                keyValue: 2,
                column: "DataCadastro",
                value: new DateTime(2022, 9, 18, 12, 47, 55, 526, DateTimeKind.Local).AddTicks(9864));

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "ProdutoId",
                keyValue: 3,
                column: "DataCadastro",
                value: new DateTime(2022, 9, 18, 12, 47, 55, 526, DateTimeKind.Local).AddTicks(9866));

            migrationBuilder.UpdateData(
                table: "Produto",
                keyColumn: "ProdutoId",
                keyValue: 4,
                column: "DataCadastro",
                value: new DateTime(2022, 9, 18, 12, 47, 55, 526, DateTimeKind.Local).AddTicks(9867));
        }
    }
}
