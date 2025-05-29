using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentOptions.Migrations
{
    /// <inheritdoc />
    public partial class add_mapping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MLobPaymentMethod_MLob_MLobsLobId",
                table: "MLobPaymentMethod");

            migrationBuilder.DropForeignKey(
                name: "FK_MLobPaymentMethod_PaymentMethod_PaymentMethodsPaymentMethodId",
                table: "MLobPaymentMethod");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentMethod_PaymentTabs_PaymentTabId",
                table: "PaymentMethod");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentMethod",
                table: "PaymentMethod");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MLob",
                table: "MLob");

            migrationBuilder.RenameTable(
                name: "PaymentMethod",
                newName: "PaymentMethods");

            migrationBuilder.RenameTable(
                name: "MLob",
                newName: "MLobs");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentMethod_PaymentTabId",
                table: "PaymentMethods",
                newName: "IX_PaymentMethods_PaymentTabId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentMethods",
                table: "PaymentMethods",
                column: "PaymentMethodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MLobs",
                table: "MLobs",
                column: "LobId");

            migrationBuilder.CreateTable(
                name: "ChannelDetails",
                columns: table => new
                {
                    ChannelDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChannelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlatformName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChannelDetails", x => x.ChannelDetailId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_MLobPaymentMethod_MLobs_MLobsLobId",
                table: "MLobPaymentMethod",
                column: "MLobsLobId",
                principalTable: "MLobs",
                principalColumn: "LobId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MLobPaymentMethod_PaymentMethods_PaymentMethodsPaymentMethodId",
                table: "MLobPaymentMethod",
                column: "PaymentMethodsPaymentMethodId",
                principalTable: "PaymentMethods",
                principalColumn: "PaymentMethodId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentMethods_PaymentTabs_PaymentTabId",
                table: "PaymentMethods",
                column: "PaymentTabId",
                principalTable: "PaymentTabs",
                principalColumn: "PaymentTabId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MLobPaymentMethod_MLobs_MLobsLobId",
                table: "MLobPaymentMethod");

            migrationBuilder.DropForeignKey(
                name: "FK_MLobPaymentMethod_PaymentMethods_PaymentMethodsPaymentMethodId",
                table: "MLobPaymentMethod");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentMethods_PaymentTabs_PaymentTabId",
                table: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "ChannelDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentMethods",
                table: "PaymentMethods");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MLobs",
                table: "MLobs");

            migrationBuilder.RenameTable(
                name: "PaymentMethods",
                newName: "PaymentMethod");

            migrationBuilder.RenameTable(
                name: "MLobs",
                newName: "MLob");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentMethods_PaymentTabId",
                table: "PaymentMethod",
                newName: "IX_PaymentMethod_PaymentTabId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentMethod",
                table: "PaymentMethod",
                column: "PaymentMethodId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MLob",
                table: "MLob",
                column: "LobId");

            migrationBuilder.AddForeignKey(
                name: "FK_MLobPaymentMethod_MLob_MLobsLobId",
                table: "MLobPaymentMethod",
                column: "MLobsLobId",
                principalTable: "MLob",
                principalColumn: "LobId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MLobPaymentMethod_PaymentMethod_PaymentMethodsPaymentMethodId",
                table: "MLobPaymentMethod",
                column: "PaymentMethodsPaymentMethodId",
                principalTable: "PaymentMethod",
                principalColumn: "PaymentMethodId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentMethod_PaymentTabs_PaymentTabId",
                table: "PaymentMethod",
                column: "PaymentTabId",
                principalTable: "PaymentTabs",
                principalColumn: "PaymentTabId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
