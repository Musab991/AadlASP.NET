using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessLib.Migrations
{
    /// <inheritdoc />
    public partial class AddConversionToTbPractitionersCasesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbPractitionerCase_TbCaseTypes_PractitionerId",
                table: "TbPractitionerCase");

            migrationBuilder.DropForeignKey(
                name: "FK_TbPractitionerCase_TbPractitioners_TbPractitionerId",
                table: "TbPractitionerCase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TbPractitionerCase",
                table: "TbPractitionerCase");

            migrationBuilder.RenameTable(
                name: "TbPractitionerCase",
                newName: "TbPractitionersCases");

            migrationBuilder.RenameIndex(
                name: "IX_TbPractitionerCase_TbPractitionerId",
                table: "TbPractitionersCases",
                newName: "IX_TbPractitionersCases_TbPractitionerId");

            migrationBuilder.RenameIndex(
                name: "IX_TbPractitionerCase_PractitionerId",
                table: "TbPractitionersCases",
                newName: "IX_TbPractitionersCases_PractitionerId");

            migrationBuilder.AlterColumn<string>(
                name: "PractitionerType",
                table: "TbPractitionersCases",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(byte),
                oldType: "tinyint");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TbPractitionersCases",
                table: "TbPractitionersCases",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TbPractitionersCases_TbCaseTypes_PractitionerId",
                table: "TbPractitionersCases",
                column: "PractitionerId",
                principalTable: "TbCaseTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TbPractitionersCases_TbPractitioners_TbPractitionerId",
                table: "TbPractitionersCases",
                column: "TbPractitionerId",
                principalTable: "TbPractitioners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbPractitionersCases_TbCaseTypes_PractitionerId",
                table: "TbPractitionersCases");

            migrationBuilder.DropForeignKey(
                name: "FK_TbPractitionersCases_TbPractitioners_TbPractitionerId",
                table: "TbPractitionersCases");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TbPractitionersCases",
                table: "TbPractitionersCases");

            migrationBuilder.RenameTable(
                name: "TbPractitionersCases",
                newName: "TbPractitionerCase");

            migrationBuilder.RenameIndex(
                name: "IX_TbPractitionersCases_TbPractitionerId",
                table: "TbPractitionerCase",
                newName: "IX_TbPractitionerCase_TbPractitionerId");

            migrationBuilder.RenameIndex(
                name: "IX_TbPractitionersCases_PractitionerId",
                table: "TbPractitionerCase",
                newName: "IX_TbPractitionerCase_PractitionerId");

            migrationBuilder.AlterColumn<byte>(
                name: "PractitionerType",
                table: "TbPractitionerCase",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TbPractitionerCase",
                table: "TbPractitionerCase",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TbPractitionerCase_TbCaseTypes_PractitionerId",
                table: "TbPractitionerCase",
                column: "PractitionerId",
                principalTable: "TbCaseTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TbPractitionerCase_TbPractitioners_TbPractitionerId",
                table: "TbPractitionerCase",
                column: "TbPractitionerId",
                principalTable: "TbPractitioners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
