using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentOptions.Migrations
{
    /// <inheritdoc />
    public partial class add_lob_in_paymenttab : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ChannelHashId",
                table: "PaymentTabs",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EnableChannelHash",
                table: "PaymentTabs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EnableLob",
                table: "PaymentTabs",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LobId",
                table: "PaymentTabs",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChannelHashId",
                table: "PaymentTabs");

            migrationBuilder.DropColumn(
                name: "EnableChannelHash",
                table: "PaymentTabs");

            migrationBuilder.DropColumn(
                name: "EnableLob",
                table: "PaymentTabs");

            migrationBuilder.DropColumn(
                name: "LobId",
                table: "PaymentTabs");
        }
    }
}
