using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpinsOnlineRazor.Migrations
{
    /// <inheritdoc />
    public partial class SexFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ValidationForm");

            migrationBuilder.DropTable(
                name: "Assessment");

            migrationBuilder.AddColumn<int>(
                name: "SexID",
                table: "Masterlist",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Sex",
                columns: table => new
                {
                    SexID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sex", x => x.SexID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Masterlist_SexID",
                table: "Masterlist",
                column: "SexID");

            migrationBuilder.AddForeignKey(
                name: "FK_Masterlist_Sex_SexID",
                table: "Masterlist",
                column: "SexID",
                principalTable: "Sex",
                principalColumn: "SexID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Masterlist_Sex_SexID",
                table: "Masterlist");

            migrationBuilder.DropTable(
                name: "Sex");

            migrationBuilder.DropIndex(
                name: "IX_Masterlist_SexID",
                table: "Masterlist");

            migrationBuilder.DropColumn(
                name: "SexID",
                table: "Masterlist");

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
                    AssessmentID = table.Column<int>(type: "INTEGER", nullable: false),
                    BeneficiaryID = table.Column<int>(type: "INTEGER", nullable: false),
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
    }
}
