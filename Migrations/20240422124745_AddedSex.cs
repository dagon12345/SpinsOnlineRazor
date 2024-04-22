using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpinsOnlineRazor.Migrations
{
    /// <inheritdoc />
    public partial class AddedSex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SexID",
                table: "Beneficiary",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Sex",
                columns: table => new
                {
                    SexID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sex", x => x.SexID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiary_SexID",
                table: "Beneficiary",
                column: "SexID");

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiary_Sex_SexID",
                table: "Beneficiary",
                column: "SexID",
                principalTable: "Sex",
                principalColumn: "SexID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiary_Sex_SexID",
                table: "Beneficiary");

            migrationBuilder.DropTable(
                name: "Sex");

            migrationBuilder.DropIndex(
                name: "IX_Beneficiary_SexID",
                table: "Beneficiary");

            migrationBuilder.DropColumn(
                name: "SexID",
                table: "Beneficiary");
        }
    }
}
