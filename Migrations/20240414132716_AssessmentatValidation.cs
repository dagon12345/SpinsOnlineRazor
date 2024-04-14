using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpinsOnlineRazor.Migrations
{
    /// <inheritdoc />
    public partial class AssessmentatValidation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Masterlist_ValidationformID",
                table: "Masterlist");

            migrationBuilder.CreateIndex(
                name: "IX_Masterlist_ValidationformID",
                table: "Masterlist",
                column: "ValidationformID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Masterlist_ValidationformID",
                table: "Masterlist");

            migrationBuilder.CreateIndex(
                name: "IX_Masterlist_ValidationformID",
                table: "Masterlist",
                column: "ValidationformID",
                unique: true);
        }
    }
}
