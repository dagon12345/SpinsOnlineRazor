using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpinsOnlineRazor.Migrations
{
    /// <inheritdoc />
    public partial class DeceasedinDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Deceased",
                columns: table => new
                {
                    DeceasedID = table.Column<int>(type: "INTEGER", nullable: false),
                    IsDeceased = table.Column<bool>(type: "INTEGER", nullable: false),
                    DeceasedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deceased", x => x.DeceasedID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Detail_DeceasedID",
                table: "Detail",
                column: "DeceasedID");

            migrationBuilder.AddForeignKey(
                name: "FK_Detail_Deceased_DeceasedID",
                table: "Detail",
                column: "DeceasedID",
                principalTable: "Deceased",
                principalColumn: "DeceasedID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Detail_Deceased_DeceasedID",
                table: "Detail");

            migrationBuilder.DropTable(
                name: "Deceased");

            migrationBuilder.DropIndex(
                name: "IX_Detail_DeceasedID",
                table: "Detail");
        }
    }
}
