using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusinessLib.Migrations
{
    /// <inheritdoc />
    public partial class Initiate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TbCountries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbCountries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TbPractitioners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PractitionerType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PractitionerSpecId = table.Column<int>(type: "int", nullable: true),
                    PersonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbPractitioners", x => x.Id);
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
                    TbCountryId = table.Column<int>(type: "int", nullable: false),
                    PractitionerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbPeople", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TbPeople_TbCountries_TbCountryId",
                        column: x => x.TbCountryId,
                        principalTable: "TbCountries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TbPeople_TbPractitioners_PractitionerId",
                        column: x => x.PractitionerId,
                        principalTable: "TbPractitioners",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_TbPeople_PractitionerId",
                table: "TbPeople",
                column: "PractitionerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TbPeople_TbCountryId",
                table: "TbPeople",
                column: "TbCountryId");

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
                name: "TbPeople");

            migrationBuilder.DropTable(
                name: "TbPractitionerSpec");

            migrationBuilder.DropTable(
                name: "TbCountries");

            migrationBuilder.DropTable(
                name: "TbPractitioners");
        }
    }
}
