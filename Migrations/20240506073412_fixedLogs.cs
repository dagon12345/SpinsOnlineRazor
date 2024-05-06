using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpinsOnlineRazor.Migrations
{
    /// <inheritdoc />
    public partial class fixedLogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Log_Beneficiary_BenficiaryID",
                table: "Log");

            migrationBuilder.RenameColumn(
                name: "BenficiaryID",
                table: "Log",
                newName: "BeneficiaryID");

            migrationBuilder.RenameIndex(
                name: "IX_Log_BenficiaryID",
                table: "Log",
                newName: "IX_Log_BeneficiaryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Log_Beneficiary_BeneficiaryID",
                table: "Log",
                column: "BeneficiaryID",
                principalTable: "Beneficiary",
                principalColumn: "BeneficiaryID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Log_Beneficiary_BeneficiaryID",
                table: "Log");

            migrationBuilder.RenameColumn(
                name: "BeneficiaryID",
                table: "Log",
                newName: "BenficiaryID");

            migrationBuilder.RenameIndex(
                name: "IX_Log_BeneficiaryID",
                table: "Log",
                newName: "IX_Log_BenficiaryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Log_Beneficiary_BenficiaryID",
                table: "Log",
                column: "BenficiaryID",
                principalTable: "Beneficiary",
                principalColumn: "BeneficiaryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
