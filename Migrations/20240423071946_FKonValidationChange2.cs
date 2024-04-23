using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpinsOnlineRazor.Migrations
{
    /// <inheritdoc />
    public partial class FKonValidationChange2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_Validationform_BeneficiaryID",
                table: "Validationform",
                column: "BeneficiaryID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Validationform_Beneficiary_BeneficiaryID",
                table: "Validationform",
                column: "BeneficiaryID",
                principalTable: "Beneficiary",
                principalColumn: "BeneficiaryID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Validationform_Beneficiary_BeneficiaryID",
                table: "Validationform");

            migrationBuilder.DropIndex(
                name: "IX_Validationform_BeneficiaryID",
                table: "Validationform");

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
    }
}
