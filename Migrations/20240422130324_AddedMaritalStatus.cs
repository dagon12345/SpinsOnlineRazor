using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpinsOnlineRazor.Migrations
{
    /// <inheritdoc />
    public partial class AddedMaritalStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaritalstatusID",
                table: "Beneficiary",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Maritalstatus",
                columns: table => new
                {
                    MaritalstatusID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maritalstatus", x => x.MaritalstatusID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiary_MaritalstatusID",
                table: "Beneficiary",
                column: "MaritalstatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiary_Maritalstatus_MaritalstatusID",
                table: "Beneficiary",
                column: "MaritalstatusID",
                principalTable: "Maritalstatus",
                principalColumn: "MaritalstatusID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiary_Maritalstatus_MaritalstatusID",
                table: "Beneficiary");

            migrationBuilder.DropTable(
                name: "Maritalstatus");

            migrationBuilder.DropIndex(
                name: "IX_Beneficiary_MaritalstatusID",
                table: "Beneficiary");

            migrationBuilder.DropColumn(
                name: "MaritalstatusID",
                table: "Beneficiary");
        }
    }
}
