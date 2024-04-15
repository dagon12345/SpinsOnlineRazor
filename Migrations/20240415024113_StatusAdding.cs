using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpinsOnlineRazor.Migrations
{
    /// <inheritdoc />
    public partial class StatusAdding : Migration
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

            migrationBuilder.AddColumn<int>(
                name: "StatusID",
                table: "Masterlist",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    StatusID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.StatusID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Masterlist_StatusID",
                table: "Masterlist",
                column: "StatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Masterlist_Status_StatusID",
                table: "Masterlist",
                column: "StatusID",
                principalTable: "Status",
                principalColumn: "StatusID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Masterlist_Status_StatusID",
                table: "Masterlist");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropIndex(
                name: "IX_Masterlist_StatusID",
                table: "Masterlist");

            migrationBuilder.DropColumn(
                name: "StatusID",
                table: "Masterlist");

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
