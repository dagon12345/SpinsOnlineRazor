using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpinsOnlineRazor.Migrations
{
    /// <inheritdoc />
    public partial class AddedBarangay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BarangayID",
                table: "Beneficiary",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Barangay",
                columns: table => new
                {
                    BarangayID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    MunicipalityID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barangay", x => x.BarangayID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiary_BarangayID",
                table: "Beneficiary",
                column: "BarangayID");

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiary_Barangay_BarangayID",
                table: "Beneficiary",
                column: "BarangayID",
                principalTable: "Barangay",
                principalColumn: "BarangayID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiary_Barangay_BarangayID",
                table: "Beneficiary");

            migrationBuilder.DropTable(
                name: "Barangay");

            migrationBuilder.DropIndex(
                name: "IX_Beneficiary_BarangayID",
                table: "Beneficiary");

            migrationBuilder.DropColumn(
                name: "BarangayID",
                table: "Beneficiary");
        }
    }
}
