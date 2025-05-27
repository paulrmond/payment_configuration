using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentOptions.Migrations
{
    /// <inheritdoc />
    public partial class testdefaultvalue_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MCarrierCode",
                keyColumn: "CarrierID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(2025, 5, 27, 15, 31, 24, 749, DateTimeKind.Utc).AddTicks(7902));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MCarrierCode",
                keyColumn: "CarrierID",
                keyValue: 1,
                column: "DateCreated",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
