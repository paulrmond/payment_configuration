using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentOptions.Migrations
{
    /// <inheritdoc />
    public partial class add_mapping_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentMethodId",
                table: "MCurrencyCode",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaymentMethodId",
                table: "MCultureCode",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MCurrencyCode_PaymentMethodId",
                table: "MCurrencyCode",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_MCultureCode_PaymentMethodId",
                table: "MCultureCode",
                column: "PaymentMethodId");

            migrationBuilder.AddForeignKey(
                name: "FK_MCultureCode_PaymentMethods_PaymentMethodId",
                table: "MCultureCode",
                column: "PaymentMethodId",
                principalTable: "PaymentMethods",
                principalColumn: "PaymentMethodId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MCurrencyCode_PaymentMethods_PaymentMethodId",
                table: "MCurrencyCode",
                column: "PaymentMethodId",
                principalTable: "PaymentMethods",
                principalColumn: "PaymentMethodId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MCultureCode_PaymentMethods_PaymentMethodId",
                table: "MCultureCode");

            migrationBuilder.DropForeignKey(
                name: "FK_MCurrencyCode_PaymentMethods_PaymentMethodId",
                table: "MCurrencyCode");

            migrationBuilder.DropIndex(
                name: "IX_MCurrencyCode_PaymentMethodId",
                table: "MCurrencyCode");

            migrationBuilder.DropIndex(
                name: "IX_MCultureCode_PaymentMethodId",
                table: "MCultureCode");

            migrationBuilder.DropColumn(
                name: "PaymentMethodId",
                table: "MCurrencyCode");

            migrationBuilder.DropColumn(
                name: "PaymentMethodId",
                table: "MCultureCode");
        }
    }
}
