using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ERP_INES.Migrations
{
    /// <inheritdoc />
    public partial class seedingsomedata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("87e05369-a276-4d3f-bfc6-3bc738a0861a"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("9f871aa1-7047-4091-92a2-4d9c3fcaa394"));

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("00bd2d40-5acc-4301-879d-e12b1c07f4d7"));

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("58cb1a10-da6a-4f42-a8be-9a972228fa20"));

            migrationBuilder.DeleteData(
                table: "TransactionCategories",
                keyColumn: "Id",
                keyValue: new Guid("023c734d-ec89-4756-9c36-574783eba24e"));

            migrationBuilder.DeleteData(
                table: "TransactionCategories",
                keyColumn: "Id",
                keyValue: new Guid("ad673da1-7c85-4301-a30f-62acd3c66187"));

            migrationBuilder.DeleteData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: new Guid("14c3dbd5-93f7-40f2-840e-661633b54d7a"));

            migrationBuilder.DeleteData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: new Guid("1b3a760f-55eb-4324-bd42-d6fcade7aa03"));

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Name", "Symbol" },
                values: new object[,]
                {
                    { new Guid("10f35f9e-7810-44b7-be37-a9d7cd6ef5f8"), "Brazilian Real", "R$" },
                    { new Guid("7df7cddf-471b-4e17-bc59-70b0ff0a144d"), "Euro", "€" }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("1d69c5c3-9887-47e3-a07d-6cffbb5051f5"), "Paid by cash", "Cash" },
                    { new Guid("a15541a5-335e-4cd9-9c2e-7240fd9a006f"), "Transferred to bank account", "Bank transfer" }
                });

            migrationBuilder.InsertData(
                table: "TransactionCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("7e9e46e8-4a54-41f2-89cb-8448960971ff"), "Assets acquisition" },
                    { new Guid("e25116d5-911d-4d3c-9a36-1edee0398de7"), "Bills" }
                });

            migrationBuilder.InsertData(
                table: "TransactionTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("92d6e7b8-a4e0-43a1-b0d7-50921e851cc4"), "Income" },
                    { new Guid("fd5e3535-5a7c-4294-abde-49e869d77957"), "Outcome" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("10f35f9e-7810-44b7-be37-a9d7cd6ef5f8"));

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: new Guid("7df7cddf-471b-4e17-bc59-70b0ff0a144d"));

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("1d69c5c3-9887-47e3-a07d-6cffbb5051f5"));

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("a15541a5-335e-4cd9-9c2e-7240fd9a006f"));

            migrationBuilder.DeleteData(
                table: "TransactionCategories",
                keyColumn: "Id",
                keyValue: new Guid("7e9e46e8-4a54-41f2-89cb-8448960971ff"));

            migrationBuilder.DeleteData(
                table: "TransactionCategories",
                keyColumn: "Id",
                keyValue: new Guid("e25116d5-911d-4d3c-9a36-1edee0398de7"));

            migrationBuilder.DeleteData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: new Guid("92d6e7b8-a4e0-43a1-b0d7-50921e851cc4"));

            migrationBuilder.DeleteData(
                table: "TransactionTypes",
                keyColumn: "Id",
                keyValue: new Guid("fd5e3535-5a7c-4294-abde-49e869d77957"));

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "Name", "Symbol" },
                values: new object[,]
                {
                    { new Guid("87e05369-a276-4d3f-bfc6-3bc738a0861a"), "Euro", "€" },
                    { new Guid("9f871aa1-7047-4091-92a2-4d9c3fcaa394"), "Brazilian Real", "R$" }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("00bd2d40-5acc-4301-879d-e12b1c07f4d7"), "Paid by cash", "Cash" },
                    { new Guid("58cb1a10-da6a-4f42-a8be-9a972228fa20"), "Transferred to bank account", "Bank transfer" }
                });

            migrationBuilder.InsertData(
                table: "TransactionCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("023c734d-ec89-4756-9c36-574783eba24e"), "Assets acquisition" },
                    { new Guid("ad673da1-7c85-4301-a30f-62acd3c66187"), "Bills" }
                });

            migrationBuilder.InsertData(
                table: "TransactionTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("14c3dbd5-93f7-40f2-840e-661633b54d7a"), "Income" },
                    { new Guid("1b3a760f-55eb-4324-bd42-d6fcade7aa03"), "Outcome" }
                });
        }
    }
}
