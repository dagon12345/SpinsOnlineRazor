using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpinsOnlineRazor.Migrations
{
    /// <inheritdoc />
    public partial class AddedMunicipality : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MunicipalityID",
                table: "Beneficiary",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Municipality",
                columns: table => new
                {
                    MunicipalityID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    ProvinceID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipality", x => x.MunicipalityID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Beneficiary_MunicipalityID",
                table: "Beneficiary",
                column: "MunicipalityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Beneficiary_Municipality_MunicipalityID",
                table: "Beneficiary",
                column: "MunicipalityID",
                principalTable: "Municipality",
                principalColumn: "MunicipalityID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beneficiary_Municipality_MunicipalityID",
                table: "Beneficiary");

            migrationBuilder.DropTable(
                name: "Municipality");

            migrationBuilder.DropIndex(
                name: "IX_Beneficiary_MunicipalityID",
                table: "Beneficiary");

            migrationBuilder.DropColumn(
                name: "MunicipalityID",
                table: "Beneficiary");
        }
    }
}
