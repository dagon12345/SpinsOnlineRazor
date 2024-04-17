using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpinsOnlineRazor.Migrations
{
    /// <inheritdoc />
    public partial class HealthStatusAdding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HealthStatusID",
                table: "Masterlist",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "HealthRemarks",
                table: "Beneficiary",
                type: "TEXT",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "HealthStatusID",
                table: "Beneficiary",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "HealthStatus",
                columns: table => new
                {
                    HealthStatusID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthStatus", x => x.HealthStatusID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Masterlist_HealthStatusID",
                table: "Masterlist",
                column: "HealthStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiary_HealthStatusID",
                table: "Beneficiary",
                column: "HealthStatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiary_HealthStatus_HealthStatusID",
                table: "Beneficiary",
                column: "HealthStatusID",
                principalTable: "HealthStatus",
                principalColumn: "HealthStatusID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Masterlist_HealthStatus_HealthStatusID",
                table: "Masterlist",
                column: "HealthStatusID",
                principalTable: "HealthStatus",
                principalColumn: "HealthStatusID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiary_HealthStatus_HealthStatusID",
                table: "Beneficiary");

            migrationBuilder.DropForeignKey(
                name: "FK_Masterlist_HealthStatus_HealthStatusID",
                table: "Masterlist");

            migrationBuilder.DropTable(
                name: "HealthStatus");

            migrationBuilder.DropIndex(
                name: "IX_Masterlist_HealthStatusID",
                table: "Masterlist");

            migrationBuilder.DropIndex(
                name: "IX_Beneficiary_HealthStatusID",
                table: "Beneficiary");

            migrationBuilder.DropColumn(
                name: "HealthStatusID",
                table: "Masterlist");

            migrationBuilder.DropColumn(
                name: "HealthRemarks",
                table: "Beneficiary");

            migrationBuilder.DropColumn(
                name: "HealthStatusID",
                table: "Beneficiary");
        }
    }
}
