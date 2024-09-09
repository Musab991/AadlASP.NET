using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessLib.Migrations
{
    /// <inheritdoc />
    public partial class newColumnsOnTbPractitionerCreatedUserDateUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedByUserId",
                table: "TbPractitioners",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "TbPractitioners",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UpdatedByUserId",
                table: "TbPractitioners",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "TbPractitioners",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByUserId",
                table: "TbPractitioners");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "TbPractitioners");

            migrationBuilder.DropColumn(
                name: "UpdatedByUserId",
                table: "TbPractitioners");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "TbPractitioners");
        }
    }
}
