using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpinsOnlineRazor.Migrations
{
    /// <inheritdoc />
    public partial class MaritalStatusAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "MaritalstatusID",
                table: "Masterlist",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MaritalStatus",
                columns: table => new
                {
                    MaritalstatusID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaritalStatus", x => x.MaritalstatusID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Masterlist_MaritalstatusID",
                table: "Masterlist",
                column: "MaritalstatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Masterlist_MaritalStatus_MaritalstatusID",
                table: "Masterlist",
                column: "MaritalstatusID",
                principalTable: "MaritalStatus",
                principalColumn: "MaritalstatusID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Masterlist_MaritalStatus_MaritalstatusID",
                table: "Masterlist");

            migrationBuilder.DropTable(
                name: "MaritalStatus");

            migrationBuilder.DropIndex(
                name: "IX_Masterlist_MaritalstatusID",
                table: "Masterlist");

            migrationBuilder.DropColumn(
                name: "MaritalstatusID",
                table: "Masterlist");

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
    }
}
