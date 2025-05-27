using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentOptions.Migrations
{
    /// <inheritdoc />
    public partial class testdefaultvalue_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "MCarrierCode",
                type: "DATE",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETUTCDATE()");

            migrationBuilder.UpdateData(
                table: "MCarrierCode",
                keyColumn: "CarrierID",
                keyValue: 1,
                column: "CreatedBy",
                value: "admin_2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "MCarrierCode",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()",
                oldClrType: typeof(DateTime),
                oldType: "DATE");

            migrationBuilder.UpdateData(
                table: "MCarrierCode",
                keyColumn: "CarrierID",
                keyValue: 1,
                column: "CreatedBy",
                value: "admin_1");
        }
    }
}
