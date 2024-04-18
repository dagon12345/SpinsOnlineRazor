using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpinsOnlineRazor.Migrations
{
    /// <inheritdoc />
    public partial class AddingDeleteModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Delete",
                columns: table => new
                {
                    DeleteID = table.Column<int>(type: "INTEGER", nullable: false),
                    IsDeleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Delete", x => x.DeleteID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Detail_DeleteID",
                table: "Detail",
                column: "DeleteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Detail_Delete_DeleteID",
                table: "Detail",
                column: "DeleteID",
                principalTable: "Delete",
                principalColumn: "DeleteID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Detail_Delete_DeleteID",
                table: "Detail");

            migrationBuilder.DropTable(
                name: "Delete");

            migrationBuilder.DropIndex(
                name: "IX_Detail_DeleteID",
                table: "Detail");
        }
    }
}
