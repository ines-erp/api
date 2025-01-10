using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ERP_INES.Migrations
{
    /// <inheritdoc />
    public partial class removingcurrecyfrompm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentMethods_Currencies_CurrencyId",
                table: "PaymentMethods");

            migrationBuilder.DropIndex(
                name: "IX_PaymentMethods_CurrencyId",
                table: "PaymentMethods");

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("10f35f9e-7810-44b7-be37-a9d7cd6ef5f8"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("7df7cddf-471b-4e17-bc59-70b0ff0a144d"));

            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "PaymentMethods");

            migrationBuilder.AddColumn<string>(
                name: "ISOCurrencySymbol",
                table: "PaymentMethods",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("1d69c5c3-9887-47e3-a07d-6cffbb5051f5"),
                column: "ISOCurrencySymbol",
                value: "EUR");

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("a15541a5-335e-4cd9-9c2e-7240fd9a006f"),
                column: "ISOCurrencySymbol",
                value: "EUR");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ISOCurrencySymbol",
                table: "PaymentMethods");

            migrationBuilder.AddColumn<Guid>(
                name: "CurrencyId",
                table: "PaymentMethods",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "ISOCode", "Name", "Symbol" },
                values: new object[,]
                {
                    { new Guid("10f35f9e-7810-44b7-be37-a9d7cd6ef5f8"), "BRL", "Brazilian Real", "R$" },
                    { new Guid("7df7cddf-471b-4e17-bc59-70b0ff0a144d"), "EUR", "Euro", "€" }
                });

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("1d69c5c3-9887-47e3-a07d-6cffbb5051f5"),
                column: "CurrencyId",
                value: new Guid("7df7cddf-471b-4e17-bc59-70b0ff0a144d"));

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("a15541a5-335e-4cd9-9c2e-7240fd9a006f"),
                column: "CurrencyId",
                value: new Guid("7df7cddf-471b-4e17-bc59-70b0ff0a144d"));

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_CurrencyId",
                table: "PaymentMethods",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentMethods_Currencies_CurrencyId",
                table: "PaymentMethods",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
