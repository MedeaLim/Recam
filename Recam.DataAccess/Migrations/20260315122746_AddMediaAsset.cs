using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Recam.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddMediaAsset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FileUrl",
                table: "MediaAssets",
                newName: "StoragePath");

            migrationBuilder.AlterColumn<int>(
                name: "MediaType",
                table: "MediaAssets",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "ContentType",
                table: "MediaAssets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "MediaAssets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<long>(
                name: "FileSize",
                table: "MediaAssets",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MediaAssets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "ListingId",
                table: "MediaAssets",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "OriginalFileName",
                table: "MediaAssets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_MediaAssets_ListingCaseId",
                table: "MediaAssets",
                column: "ListingCaseId");

            migrationBuilder.AddForeignKey(
                name: "FK_MediaAssets_ListingCases_ListingCaseId",
                table: "MediaAssets",
                column: "ListingCaseId",
                principalTable: "ListingCases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MediaAssets_ListingCases_ListingCaseId",
                table: "MediaAssets");

            migrationBuilder.DropIndex(
                name: "IX_MediaAssets_ListingCaseId",
                table: "MediaAssets");

            migrationBuilder.DropColumn(
                name: "ContentType",
                table: "MediaAssets");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "MediaAssets");

            migrationBuilder.DropColumn(
                name: "FileSize",
                table: "MediaAssets");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MediaAssets");

            migrationBuilder.DropColumn(
                name: "ListingId",
                table: "MediaAssets");

            migrationBuilder.DropColumn(
                name: "OriginalFileName",
                table: "MediaAssets");

            migrationBuilder.RenameColumn(
                name: "StoragePath",
                table: "MediaAssets",
                newName: "FileUrl");

            migrationBuilder.AlterColumn<string>(
                name: "MediaType",
                table: "MediaAssets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
