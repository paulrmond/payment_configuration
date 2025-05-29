using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentOptions.Migrations
{
    /// <inheritdoc />
    public partial class add_mapping_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MCultureCode_PaymentMethods_PaymentMethodId",
                table: "MCultureCode");

            migrationBuilder.DropForeignKey(
                name: "FK_MCurrencyCode_PaymentMethods_PaymentMethodId",
                table: "MCurrencyCode");

            migrationBuilder.DropTable(
                name: "MLobPaymentMethod");

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

            migrationBuilder.AddColumn<string>(
                name: "CultureIds",
                table: "PaymentMethods",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CurrencyIds",
                table: "PaymentMethods",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MLobLobId",
                table: "PaymentMethods",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MLobs",
                table: "PaymentMethods",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethods_MLobLobId",
                table: "PaymentMethods",
                column: "MLobLobId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentMethods_MLobs_MLobLobId",
                table: "PaymentMethods",
                column: "MLobLobId",
                principalTable: "MLobs",
                principalColumn: "LobId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentMethods_MLobs_MLobLobId",
                table: "PaymentMethods");

            migrationBuilder.DropIndex(
                name: "IX_PaymentMethods_MLobLobId",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "CultureIds",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "CurrencyIds",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "MLobLobId",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "MLobs",
                table: "PaymentMethods");

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

            migrationBuilder.CreateTable(
                name: "MLobPaymentMethod",
                columns: table => new
                {
                    MLobsLobId = table.Column<int>(type: "int", nullable: false),
                    PaymentMethodsPaymentMethodId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MLobPaymentMethod", x => new { x.MLobsLobId, x.PaymentMethodsPaymentMethodId });
                    table.ForeignKey(
                        name: "FK_MLobPaymentMethod_MLobs_MLobsLobId",
                        column: x => x.MLobsLobId,
                        principalTable: "MLobs",
                        principalColumn: "LobId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MLobPaymentMethod_PaymentMethods_PaymentMethodsPaymentMethodId",
                        column: x => x.PaymentMethodsPaymentMethodId,
                        principalTable: "PaymentMethods",
                        principalColumn: "PaymentMethodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MCurrencyCode_PaymentMethodId",
                table: "MCurrencyCode",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_MCultureCode_PaymentMethodId",
                table: "MCultureCode",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_MLobPaymentMethod_PaymentMethodsPaymentMethodId",
                table: "MLobPaymentMethod",
                column: "PaymentMethodsPaymentMethodId");

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
    }
}
