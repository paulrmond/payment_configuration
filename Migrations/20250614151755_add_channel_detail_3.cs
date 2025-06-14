using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentOptions.Migrations
{
    /// <inheritdoc />
    public partial class add_channel_detail_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ChannelDetails",
                table: "ChannelDetails");

            migrationBuilder.RenameTable(
                name: "ChannelDetails",
                newName: "MChannelDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MChannelDetails",
                table: "MChannelDetails",
                column: "ChannelDetailId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MChannelDetails",
                table: "MChannelDetails");

            migrationBuilder.RenameTable(
                name: "MChannelDetails",
                newName: "ChannelDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChannelDetails",
                table: "ChannelDetails",
                column: "ChannelDetailId");
        }
    }
}
