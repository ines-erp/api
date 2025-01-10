using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP_INES.Migrations
{
    /// <inheritdoc />
    public partial class currencyintopaymentmethod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CurrencyId",
                table: "PaymentMethods",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "ISOCode",
                table: "Currencies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("10f35f9e-7810-44b7-be37-a9d7cd6ef5f8"),
                column: "ISOCode",
                value: "BRL");

            migrationBuilder.UpdateData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("7df7cddf-471b-4e17-bc59-70b0ff0a144d"),
                column: "ISOCode",
                value: "EUR");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrencyId",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "ISOCode",
                table: "Currencies");
        }
    }
}
