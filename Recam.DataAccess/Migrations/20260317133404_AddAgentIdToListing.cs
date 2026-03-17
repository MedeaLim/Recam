using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recam.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddAgentIdToListing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AgentId",
                table: "ListingCases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "ListingCases");
        }
    }
}
