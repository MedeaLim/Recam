using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recam.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminIdToAgent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AdminId",
                table: "Agents",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminId",
                table: "Agents");
        }
    }
}
