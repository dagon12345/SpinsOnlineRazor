using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpinsOnlineRazor.Migrations
{
    /// <inheritdoc />
    public partial class AddedDetailsExclusion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DetailID",
                table: "Masterlist",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Exclusion",
                columns: table => new
                {
                    ExclusionID = table.Column<int>(type: "INTEGER", nullable: false),
                    IsExcluded = table.Column<bool>(type: "INTEGER", nullable: false),
                    ExclusionBatch = table.Column<string>(type: "TEXT", nullable: true),
                    ExclusionDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exclusion", x => x.ExclusionID);
                });

            migrationBuilder.CreateTable(
                name: "Detail",
                columns: table => new
                {
                    DetailID = table.Column<int>(type: "INTEGER", nullable: false),
                    DateEntered = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EnteredBy = table.Column<string>(type: "TEXT", nullable: true),
                    InclusionDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ExclusionID = table.Column<int>(type: "INTEGER", nullable: true),
                    DeceasedID = table.Column<int>(type: "INTEGER", nullable: true),
                    ModifyID = table.Column<int>(type: "INTEGER", nullable: true),
                    DeleteID = table.Column<int>(type: "INTEGER", nullable: true),
                    WaitlistedID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detail", x => x.DetailID);
                    table.ForeignKey(
                        name: "FK_Detail_Exclusion_ExclusionID",
                        column: x => x.ExclusionID,
                        principalTable: "Exclusion",
                        principalColumn: "ExclusionID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Masterlist_DetailID",
                table: "Masterlist",
                column: "DetailID");

            migrationBuilder.CreateIndex(
                name: "IX_Detail_ExclusionID",
                table: "Detail",
                column: "ExclusionID");

            migrationBuilder.AddForeignKey(
                name: "FK_Masterlist_Detail_DetailID",
                table: "Masterlist",
                column: "DetailID",
                principalTable: "Detail",
                principalColumn: "DetailID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Masterlist_Detail_DetailID",
                table: "Masterlist");

            migrationBuilder.DropTable(
                name: "Detail");

            migrationBuilder.DropTable(
                name: "Exclusion");

            migrationBuilder.DropIndex(
                name: "IX_Masterlist_DetailID",
                table: "Masterlist");

            migrationBuilder.DropColumn(
                name: "DetailID",
                table: "Masterlist");
        }
    }
}
