using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessLib.Migrations
{
    /// <inheritdoc />
    public partial class ChangedateTimeColumnInTbPerson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbPractitionerSpec_TbPractitioners_PractitionerId",
                table: "TbPractitionerSpec");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TbPractitionerSpec",
                table: "TbPractitionerSpec");

            migrationBuilder.RenameTable(
                name: "TbPractitionerSpec",
                newName: "TbPractitionerSpecs");

            migrationBuilder.RenameIndex(
                name: "IX_TbPractitionerSpec_PractitionerId",
                table: "TbPractitionerSpecs",
                newName: "IX_TbPractitionerSpecs_PractitionerId");

            migrationBuilder.AlterColumn<DateTime>(
            name: "UpdateDate",
            table: "TbPeople",
            type: "datetime",
            nullable: true,
            oldClrType: typeof(int),
            oldType: "int",
            oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TbPractitionerSpecs",
                table: "TbPractitionerSpecs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TbPractitionerSpecs_TbPractitioners_PractitionerId",
                table: "TbPractitionerSpecs",
                column: "PractitionerId",
                principalTable: "TbPractitioners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbPractitionerSpecs_TbPractitioners_PractitionerId",
                table: "TbPractitionerSpecs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TbPractitionerSpecs",
                table: "TbPractitionerSpecs");

            migrationBuilder.RenameTable(
                name: "TbPractitionerSpecs",
                newName: "TbPractitionerSpec");

            migrationBuilder.RenameIndex(
                name: "IX_TbPractitionerSpecs_PractitionerId",
                table: "TbPractitionerSpec",
                newName: "IX_TbPractitionerSpec_PractitionerId");

            migrationBuilder.AlterColumn<int>(
                name: "UpdateDate",
                table: "TbPeople",
                type: "int",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TbPractitionerSpec",
                table: "TbPractitionerSpec",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TbPractitionerSpec_TbPractitioners_PractitionerId",
                table: "TbPractitionerSpec",
                column: "PractitionerId",
                principalTable: "TbPractitioners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
