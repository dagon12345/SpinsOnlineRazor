using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpinsOnlineRazor.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HealthStatus",
                columns: table => new
                {
                    HealthStatusID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthStatus", x => x.HealthStatusID);
                });

            migrationBuilder.CreateTable(
                name: "IdentificationType",
                columns: table => new
                {
                    IdentificationTypeID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentificationType", x => x.IdentificationTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    RegionID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.RegionID);
                });

            migrationBuilder.CreateTable(
                name: "Beneficiary",
                columns: table => new
                {
                    BeneficiaryID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LastName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    MiddleName = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    ExtName = table.Column<string>(type: "TEXT", maxLength: 3, nullable: true),
                    BirthDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    IdentificationTypeID = table.Column<int>(type: "INTEGER", nullable: false),
                    IdentificationNumber = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    IdentificationDateIssued = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SpecificAddress = table.Column<string>(type: "TEXT", maxLength: 20, nullable: true),
                    ContactNumber = table.Column<string>(type: "TEXT", maxLength: 11, nullable: true),
                    HealthStatusID = table.Column<int>(type: "INTEGER", nullable: false),
                    HealthRemarks = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    RegionID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beneficiary", x => x.BeneficiaryID);
                    table.ForeignKey(
                        name: "FK_Beneficiary_HealthStatus_HealthStatusID",
                        column: x => x.HealthStatusID,
                        principalTable: "HealthStatus",
                        principalColumn: "HealthStatusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Beneficiary_IdentificationType_IdentificationTypeID",
                        column: x => x.IdentificationTypeID,
                        principalTable: "IdentificationType",
                        principalColumn: "IdentificationTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Beneficiary_Region_RegionID",
                        column: x => x.RegionID,
                        principalTable: "Region",
                        principalColumn: "RegionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiary_HealthStatusID",
                table: "Beneficiary",
                column: "HealthStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiary_IdentificationTypeID",
                table: "Beneficiary",
                column: "IdentificationTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiary_RegionID",
                table: "Beneficiary",
                column: "RegionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Beneficiary");

            migrationBuilder.DropTable(
                name: "HealthStatus");

            migrationBuilder.DropTable(
                name: "IdentificationType");

            migrationBuilder.DropTable(
                name: "Region");
        }
    }
}
