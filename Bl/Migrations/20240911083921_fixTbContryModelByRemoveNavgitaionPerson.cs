using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessLib.Migrations
{
    /// <inheritdoc />
    public partial class fixTbContryModelByRemoveNavgitaionPerson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbPeople_TbCounrties_TbCountryId",
                table: "TbPeople");

            migrationBuilder.DropIndex(
                name: "IX_TbPeople_TbCountryId",
                table: "TbPeople");

            migrationBuilder.DropColumn(
                name: "TbCountryId",
                table: "TbPeople");

            migrationBuilder.CreateIndex(
                name: "IX_TbPeople_CountryId",
                table: "TbPeople",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbPeople_TbCounrties_CountryId",
                table: "TbPeople",
                column: "CountryId",
                principalTable: "TbCounrties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbPeople_TbCounrties_CountryId",
                table: "TbPeople");

            migrationBuilder.DropIndex(
                name: "IX_TbPeople_CountryId",
                table: "TbPeople");

            migrationBuilder.AddColumn<int>(
                name: "TbCountryId",
                table: "TbPeople",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TbPeople_TbCountryId",
                table: "TbPeople",
                column: "TbCountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbPeople_TbCounrties_TbCountryId",
                table: "TbPeople",
                column: "TbCountryId",
                principalTable: "TbCounrties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
