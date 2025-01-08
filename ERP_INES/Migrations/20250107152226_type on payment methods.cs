using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP_INES.Migrations
{
    /// <inheritdoc />
    public partial class typeonpaymentmethods : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "PaymentMethods",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("1d69c5c3-9887-47e3-a07d-6cffbb5051f5"),
                columns: new[] { "Description", "Name", "Type" },
                values: new object[] { "The VISA card with end 4504 on the Santander account in the name of the company", "Debit card 4504", "Card" });

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("a15541a5-335e-4cd9-9c2e-7240fd9a006f"),
                columns: new[] { "Description", "Name", "Type" },
                values: new object[] { "Transferred to Santander bank account", "Santander", "Bank transfer" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "PaymentMethods");

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("1d69c5c3-9887-47e3-a07d-6cffbb5051f5"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Paid by cash", "Cash" });

            migrationBuilder.UpdateData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("a15541a5-335e-4cd9-9c2e-7240fd9a006f"),
                columns: new[] { "Description", "Name" },
                values: new object[] { "Transferred to bank account", "Bank transfer" });
        }
    }
}
