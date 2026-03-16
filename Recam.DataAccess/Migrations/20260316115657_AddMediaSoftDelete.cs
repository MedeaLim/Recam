using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recam.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddMediaSoftDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ListingId",
                table: "MediaAssets");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ListingId",
                table: "MediaAssets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }
    }
}
