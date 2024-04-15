using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpinsOnlineRazor.Migrations
{
    /// <inheritdoc />
    public partial class IdentificationType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdentificationTypeID",
                table: "Masterlist",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "IdentificationType",
                columns: table => new
                {
                    IdentificationTypeID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentificationType", x => x.IdentificationTypeID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Masterlist_IdentificationTypeID",
                table: "Masterlist",
                column: "IdentificationTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Masterlist_IdentificationType_IdentificationTypeID",
                table: "Masterlist",
                column: "IdentificationTypeID",
                principalTable: "IdentificationType",
                principalColumn: "IdentificationTypeID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Masterlist_IdentificationType_IdentificationTypeID",
                table: "Masterlist");

            migrationBuilder.DropTable(
                name: "IdentificationType");

            migrationBuilder.DropIndex(
                name: "IX_Masterlist_IdentificationTypeID",
                table: "Masterlist");

            migrationBuilder.DropColumn(
                name: "IdentificationTypeID",
                table: "Masterlist");
        }
    }
}
