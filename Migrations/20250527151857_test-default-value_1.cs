using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentOptions.Migrations
{
    /// <inheritdoc />
    public partial class testdefaultvalue_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MCarrierCode",
                keyColumn: "CarrierID",
                keyValue: 1,
                column: "CreatedBy",
                value: "admin_1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "MCarrierCode",
                keyColumn: "CarrierID",
                keyValue: 1,
                column: "CreatedBy",
                value: "admin");
        }
    }
}
