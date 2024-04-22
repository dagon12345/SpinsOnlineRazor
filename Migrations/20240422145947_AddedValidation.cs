using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpinsOnlineRazor.Migrations
{
    /// <inheritdoc />
    public partial class AddedValidation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ValidationformID",
                table: "Beneficiary",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Validationform",
                columns: table => new
                {
                    ValidationformID = table.Column<int>(type: "INTEGER", nullable: false),
                    AssessmentID = table.Column<int>(type: "INTEGER", nullable: false),
                    ReferenceCode = table.Column<int>(type: "INTEGER", nullable: false),
                    SpinsBatch = table.Column<int>(type: "INTEGER", nullable: true),
                    Pantawid = table.Column<bool>(type: "INTEGER", nullable: false),
                    Indigenous = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Validationform", x => x.ValidationformID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiary_ValidationformID",
                table: "Beneficiary",
                column: "ValidationformID");

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiary_Validationform_ValidationformID",
                table: "Beneficiary",
                column: "ValidationformID",
                principalTable: "Validationform",
                principalColumn: "ValidationformID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiary_Validationform_ValidationformID",
                table: "Beneficiary");

            migrationBuilder.DropTable(
                name: "Validationform");

            migrationBuilder.DropIndex(
                name: "IX_Beneficiary_ValidationformID",
                table: "Beneficiary");

            migrationBuilder.DropColumn(
                name: "ValidationformID",
                table: "Beneficiary");
        }
    }
}
