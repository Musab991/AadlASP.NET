using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BusinessLib.Migrations
{
    /// <inheritdoc />
    public partial class initaitemigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbCounrties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbCounrties", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbPractitionerTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PractitionerTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbPractitionerTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbPeople",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ThirdName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateByUserId = table.Column<int>(type: "int", nullable: true),
                    UpdateDate = table.Column<int>(type: "int", nullable: true),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TbCountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbPeople", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbPeople_TbCounrties_TbCountryId",
                        column: x => x.TbCountryId,
                        principalTable: "TbCounrties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TbCaseTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PractitionerTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbCaseTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbCaseTypes_TbPractitionerTypes_PractitionerTypeId",
                        column: x => x.PractitionerTypeId,
                        principalTable: "TbPractitionerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TbPractitioners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PractitionerTypeId = table.Column<int>(type: "int", nullable: false),
                    PractitionerSpecId = table.Column<int>(type: "int", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    CreatedByUserId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedByUserId = table.Column<int>(type: "int", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbPractitioners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbPractitioners_TbPeople_PersonId",
                        column: x => x.PersonId,
                        principalTable: "TbPeople",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TbPractitioners_TbPractitionerTypes_PractitionerTypeId",
                        column: x => x.PractitionerTypeId,
                        principalTable: "TbPractitionerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TbPractitionersCases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PractitionerId = table.Column<int>(type: "int", nullable: false),
                    CaseId = table.Column<int>(type: "int", nullable: false),
                    PractitionerTypeId = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbPractitionersCases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbPractitionersCases_TbCaseTypes_PractitionerId",
                        column: x => x.PractitionerId,
                        principalTable: "TbCaseTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TbPractitionersCases_TbPractitionerTypes_PractitionerTypeId",
                        column: x => x.PractitionerTypeId,
                        principalTable: "TbPractitionerTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TbPractitionerSpec",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PractitionerId = table.Column<int>(type: "int", nullable: false),
                    RegulatorMembershipNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RegulatorSubscriptionType = table.Column<byte>(type: "tinyint", nullable: true),
                    RegulatorSubscriptionWay = table.Column<byte>(type: "tinyint", nullable: true),
                    ShariaLicenseNubmer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShariaSubscriptionType = table.Column<byte>(type: "tinyint", nullable: true),
                    ShariaSubscriptionWay = table.Column<byte>(type: "tinyint", nullable: true),
                    JudgerSubscriptionType = table.Column<byte>(type: "tinyint", nullable: true),
                    JudgerSubscriptionWay = table.Column<byte>(type: "tinyint", nullable: true),
                    ExpertSubscriptionType = table.Column<byte>(type: "tinyint", nullable: true),
                    ExpertSubscriptionWay = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbPractitionerSpec", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbPractitionerSpec_TbPractitioners_PractitionerId",
                        column: x => x.PractitionerId,
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
                name: "IX_TbCaseTypes_PractitionerTypeId",
                table: "TbCaseTypes",
                column: "PractitionerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TbPeople_TbCountryId",
                table: "TbPeople",
                column: "TbCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_TbPractitioners_PersonId",
                table: "TbPractitioners",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TbPractitioners_PractitionerTypeId",
                table: "TbPractitioners",
                column: "PractitionerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TbPractitionersCases_PractitionerId",
                table: "TbPractitionersCases",
                column: "PractitionerId");

            migrationBuilder.CreateIndex(
                name: "IX_TbPractitionersCases_PractitionerTypeId",
                table: "TbPractitionersCases",
                column: "PractitionerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TbPractitionerSpec_PractitionerId",
                table: "TbPractitionerSpec",
                column: "PractitionerId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbPractitionersCases");

            migrationBuilder.DropTable(
                name: "TbPractitionerSpec");

            migrationBuilder.DropTable(
                name: "TbCaseTypes");

            migrationBuilder.DropTable(
                name: "TbPractitioners");

            migrationBuilder.DropTable(
                name: "TbPeople");

            migrationBuilder.DropTable(
                name: "TbPractitionerTypes");

            migrationBuilder.DropTable(
                name: "TbCounrties");
        }
    }
}
