using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpinsOnlineRazor.Migrations
{
    /// <inheritdoc />
    public partial class AddedValidationInBene : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ValidationformID",
                table: "Beneficiary",
                type: "INTEGER",
                nullable: true);

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

            migrationBuilder.DropIndex(
                name: "IX_Beneficiary_ValidationformID",
                table: "Beneficiary");

            migrationBuilder.DropColumn(
                name: "ValidationformID",
                table: "Beneficiary");
        }
    }
}
