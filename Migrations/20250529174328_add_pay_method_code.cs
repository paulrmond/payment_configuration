using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentOptions.Migrations
{
    /// <inheritdoc />
    public partial class add_pay_method_code : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MLob",
                columns: table => new
                {
                    LobId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LobName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChannelHash = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MLob", x => x.LobId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                columns: table => new
                {
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayMethodCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PayMethodName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PreExpand = table.Column<int>(type: "int", nullable: false),
                    SortOrder = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<int>(type: "int", nullable: false),
                    ProcessingFeeCodes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupportedBanksImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GatewayId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FiCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SessionId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoreInfoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PaymentTabId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethod", x => x.PaymentMethodId);
                    table.ForeignKey(
                        name: "FK_PaymentMethod_PaymentTabs_PaymentTabId",
                        column: x => x.PaymentTabId,
                        principalTable: "PaymentTabs",
                        principalColumn: "PaymentTabId",
                        onDelete: ReferentialAction.Cascade);
                });

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
                        name: "FK_MLobPaymentMethod_MLob_MLobsLobId",
                        column: x => x.MLobsLobId,
                        principalTable: "MLob",
                        principalColumn: "LobId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MLobPaymentMethod_PaymentMethod_PaymentMethodsPaymentMethodId",
                        column: x => x.PaymentMethodsPaymentMethodId,
                        principalTable: "PaymentMethod",
                        principalColumn: "PaymentMethodId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MLobPaymentMethod_PaymentMethodsPaymentMethodId",
                table: "MLobPaymentMethod",
                column: "PaymentMethodsPaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethod_PaymentTabId",
                table: "PaymentMethod",
                column: "PaymentTabId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MLobPaymentMethod");

            migrationBuilder.DropTable(
                name: "MLob");

            migrationBuilder.DropTable(
                name: "PaymentMethod");
        }
    }
}
