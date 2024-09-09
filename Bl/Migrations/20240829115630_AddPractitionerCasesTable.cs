using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessLib.Migrations
{
    /// <inheritdoc />
    public partial class AddPractitionerCasesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbPeople_TbCountries_TbCountryId",
                table: "TbPeople");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TbCountries",
                table: "TbCountries");

            migrationBuilder.RenameTable(
                name: "TbCountries",
                newName: "TbCounrties");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TbCounrties",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TbCounrties",
                table: "TbCounrties",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TbCaseTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PractitionerType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbCaseTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbPractitionerCase",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PractitionerId = table.Column<int>(type: "int", nullable: false),
                    CaseId = table.Column<int>(type: "int", nullable: false),
                    PractitionerType = table.Column<byte>(type: "tinyint", nullable: false),
                    TbPractitionerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbPractitionerCase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbPractitionerCase_TbCaseTypes_PractitionerId",
                        column: x => x.PractitionerId,
                        principalTable: "TbCaseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TbPractitionerCase_TbPractitioners_TbPractitionerId",
                        column: x => x.TbPractitionerId,
                        principalTable: "TbPractitioners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "TbCounrties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "United States" },
                    { 2, "Canada" },
                    { 3, "Mexico" },
                    { 4, "Brazil" },
                    { 5, "Argentina" },
                    { 6, "United Kingdom" },
                    { 7, "Germany" },
                    { 8, "France" },
                    { 9, "Italy" },
                    { 10, "Spain" },
                    { 11, "Russia" },
                    { 12, "China" },
                    { 13, "Japan" },
                    { 14, "South Korea" },
                    { 15, "India" },
                    { 16, "Australia" },
                    { 17, "New Zealand" },
                    { 18, "South Africa" },
                    { 19, "Egypt" },
                    { 20, "Nigeria" },
                    { 21, "Kenya" },
                    { 22, "Saudi Arabia" },
                    { 23, "United Arab Emirates" },
                    { 24, "Turkey" },
                    { 25, "Iran" },
                    { 26, "Israel" },
                    { 27, "Pakistan" },
                    { 28, "Bangladesh" },
                    { 29, "Indonesia" },
                    { 30, "Vietnam" },
                    { 31, "Thailand" },
                    { 32, "Malaysia" },
                    { 33, "Singapore" },
                    { 34, "Philippines" },
                    { 35, "Greece" },
                    { 36, "Sweden" },
                    { 37, "Norway" },
                    { 38, "Denmark" },
                    { 39, "Finland" },
                    { 40, "Poland" },
                    { 41, "Netherlands" },
                    { 42, "Belgium" },
                    { 43, "Switzerland" },
                    { 44, "Austria" },
                    { 45, "Portugal" },
                    { 46, "Chile" },
                    { 47, "Colombia" },
                    { 48, "Peru" },
                    { 49, "Venezuela" },
                    { 50, "Cuba" },
                    { 51, "Jordan" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbPractitionerCase_PractitionerId",
                table: "TbPractitionerCase",
                column: "PractitionerId");

            migrationBuilder.CreateIndex(
                name: "IX_TbPractitionerCase_TbPractitionerId",
                table: "TbPractitionerCase",
                column: "TbPractitionerId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbPeople_TbCounrties_TbCountryId",
                table: "TbPeople",
                column: "TbCountryId",
                principalTable: "TbCounrties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbPeople_TbCounrties_TbCountryId",
                table: "TbPeople");

            migrationBuilder.DropTable(
                name: "TbPractitionerCase");

            migrationBuilder.DropTable(
                name: "TbCaseTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TbCounrties",
                table: "TbCounrties");

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "TbCounrties",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.RenameTable(
                name: "TbCounrties",
                newName: "TbCountries");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "TbCountries",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TbCountries",
                table: "TbCountries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TbPeople_TbCountries_TbCountryId",
                table: "TbPeople",
                column: "TbCountryId",
                principalTable: "TbCountries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
