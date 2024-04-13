using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpinsOnlineRazor.Migrations
{
    /// <inheritdoc />
    public partial class ValAssessSexMarital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "Beneficiary",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "Assessment",
                columns: table => new
                {
                    AssessmentID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assessment", x => x.AssessmentID);
                });

            migrationBuilder.CreateTable(
                name: "ValidationForm",
                columns: table => new
                {
                    ValidationformID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BeneficiaryID = table.Column<int>(type: "INTEGER", nullable: false),
                    AssessmentID = table.Column<int>(type: "INTEGER", nullable: false),
                    ReferenceCode = table.Column<int>(type: "INTEGER", nullable: false),
                    SpinsBatch = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValidationForm", x => x.ValidationformID);
                    table.ForeignKey(
                        name: "FK_ValidationForm_Assessment_AssessmentID",
                        column: x => x.AssessmentID,
                        principalTable: "Assessment",
                        principalColumn: "AssessmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ValidationForm_Beneficiary_BeneficiaryID",
                        column: x => x.BeneficiaryID,
                        principalTable: "Beneficiary",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ValidationForm_AssessmentID",
                table: "ValidationForm",
                column: "AssessmentID");

            migrationBuilder.CreateIndex(
                name: "IX_ValidationForm_BeneficiaryID",
                table: "ValidationForm",
                column: "BeneficiaryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ValidationForm");

            migrationBuilder.DropTable(
                name: "Assessment");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "Beneficiary");
        }
    }
}
