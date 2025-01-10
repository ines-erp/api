using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP_INES.Migrations
{
    /// <inheritdoc />
    public partial class currencytablepaymentmethod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentMethods_Currencies_CurrencyId",
                table: "PaymentMethods");

            migrationBuilder.DropIndex(
                name: "IX_PaymentMethods_CurrencyId",
                table: "PaymentMethods");
        }
    }
}
