using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SubscribersAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Subscribers",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DailyNewsletter = table.Column<bool>(type: "bit", nullable: true),
                    AdvertisingUpdates = table.Column<bool>(type: "bit", nullable: true),
                    WeekinReview = table.Column<bool>(type: "bit", nullable: true),
                    EventUpdates = table.Column<bool>(type: "bit", nullable: true),
                    StartupsWeekly = table.Column<bool>(type: "bit", nullable: true),
                    Podcasts = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscribers", x => x.Email);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Subscribers");
        }
    }
}
