using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentOptions.Migrations
{
    /// <inheritdoc />
    public partial class add_mapping_4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentMethods_MLobs_MLobLobId",
                table: "PaymentMethods");

            migrationBuilder.DropIndex(
                name: "IX_PaymentMethods_MLobLobId",
                table: "PaymentMethods");

            migrationBuilder.DropColumn(
                name: "MLobLobId",
                table: "PaymentMethods");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MLobLobId",
                table: "PaymentMethods",
                type: "int",
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
    }
}
