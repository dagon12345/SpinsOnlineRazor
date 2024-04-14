using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpinsOnlineRazor.Migrations
{
    /// <inheritdoc />
    public partial class ChangeofID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Beneficiary",
                newName: "BeneficiaryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BeneficiaryID",
                table: "Beneficiary",
                newName: "ID");
        }
    }
}
