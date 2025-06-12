using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaymentOptions.Migrations
{
    /// <inheritdoc />
    public partial class add_lob_in_paymenttab_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MChannelHashes",
                columns: table => new
                {
                    ChannelHashId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChannelHashName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChannelHashInfo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChannelHash = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MChannelHashes", x => x.ChannelHashId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MChannelHashes");
        }
    }
}
