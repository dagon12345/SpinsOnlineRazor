using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpinsOnlineRazor.Migrations
{
    /// <inheritdoc />
    public partial class AddedAssessment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Validationform_AssessmentID",
                table: "Validationform",
                column: "AssessmentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Validationform_Assessment_AssessmentID",
                table: "Validationform",
                column: "AssessmentID",
                principalTable: "Assessment",
                principalColumn: "AssessmentID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Validationform_Assessment_AssessmentID",
                table: "Validationform");

            migrationBuilder.DropTable(
                name: "Assessment");

            migrationBuilder.DropIndex(
                name: "IX_Validationform_AssessmentID",
                table: "Validationform");
        }
    }
}
