using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpinsOnlineRazor.Migrations
{
    /// <inheritdoc />
    public partial class SexAddedinBene : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SexID",
                table: "Beneficiary",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiary_SexID",
                table: "Beneficiary",
                column: "SexID");

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiary_Sex_SexID",
                table: "Beneficiary",
                column: "SexID",
                principalTable: "Sex",
                principalColumn: "SexID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiary_Sex_SexID",
                table: "Beneficiary");

            migrationBuilder.DropIndex(
                name: "IX_Beneficiary_SexID",
                table: "Beneficiary");

            migrationBuilder.DropColumn(
                name: "SexID",
                table: "Beneficiary");
        }
    }
}
