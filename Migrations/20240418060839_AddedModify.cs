using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpinsOnlineRazor.Migrations
{
    /// <inheritdoc />
    public partial class AddedModify : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Modify",
                columns: table => new
                {
                    ModifyID = table.Column<int>(type: "INTEGER", nullable: false),
                    IsModified = table.Column<bool>(type: "INTEGER", nullable: false),
                    ModifiedBy = table.Column<string>(type: "TEXT", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modify", x => x.ModifyID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Detail_ModifyID",
                table: "Detail",
                column: "ModifyID");

            migrationBuilder.AddForeignKey(
                name: "FK_Detail_Modify_ModifyID",
                table: "Detail",
                column: "ModifyID",
                principalTable: "Modify",
                principalColumn: "ModifyID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Detail_Modify_ModifyID",
                table: "Detail");

            migrationBuilder.DropTable(
                name: "Modify");

            migrationBuilder.DropIndex(
                name: "IX_Detail_ModifyID",
                table: "Detail");
        }
    }
}
