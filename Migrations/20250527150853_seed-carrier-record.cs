using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentOptions.Migrations
{
    /// <inheritdoc />
    public partial class seedcarrierrecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MCarrierCode",
                columns: new[] { "CarrierID", "CarrierCode", "Code", "CreatedBy", "DateCreated" },
                values: new object[] { 1, "AK", 1, "admin", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MCarrierCode",
                keyColumn: "CarrierID",
                keyValue: 1);
        }
    }
}
