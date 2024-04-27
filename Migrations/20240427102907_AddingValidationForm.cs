using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpinsOnlineRazor.Migrations
{
    /// <inheritdoc />
    public partial class AddingValidationForm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Validationform_Beneficiary_BeneficiaryID",
                table: "Validationform");

            migrationBuilder.AlterColumn<int>(
                name: "BeneficiaryID",
                table: "Validationform",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Validationform_Beneficiary_BeneficiaryID",
                table: "Validationform",
                column: "BeneficiaryID",
                principalTable: "Beneficiary",
                principalColumn: "BeneficiaryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Validationform_Beneficiary_BeneficiaryID",
                table: "Validationform");

            migrationBuilder.AlterColumn<int>(
                name: "BeneficiaryID",
                table: "Validationform",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Validationform_Beneficiary_BeneficiaryID",
                table: "Validationform",
                column: "BeneficiaryID",
                principalTable: "Beneficiary",
                principalColumn: "BeneficiaryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
