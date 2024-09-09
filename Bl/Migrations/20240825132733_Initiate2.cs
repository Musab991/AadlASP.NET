using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessLib.Migrations
{
    /// <inheritdoc />
    public partial class Initiate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbPeople_TbPractitioners_PractitionerId",
                table: "TbPeople");

            migrationBuilder.DropIndex(
                name: "IX_TbPeople_PractitionerId",
                table: "TbPeople");

            migrationBuilder.DropColumn(
                name: "PractitionerId",
                table: "TbPeople");

            migrationBuilder.CreateIndex(
                name: "IX_TbPractitioners_PersonId",
                table: "TbPractitioners",
                column: "PersonId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TbPractitioners_TbPeople_PersonId",
                table: "TbPractitioners",
                column: "PersonId",
                principalTable: "TbPeople",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbPractitioners_TbPeople_PersonId",
                table: "TbPractitioners");

            migrationBuilder.DropIndex(
                name: "IX_TbPractitioners_PersonId",
                table: "TbPractitioners");

            migrationBuilder.AddColumn<int>(
                name: "PractitionerId",
                table: "TbPeople",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TbPeople_PractitionerId",
                table: "TbPeople",
                column: "PractitionerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_TbPeople_TbPractitioners_PractitionerId",
                table: "TbPeople",
                column: "PractitionerId",
                principalTable: "TbPractitioners",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
