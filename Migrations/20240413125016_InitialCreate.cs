using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpinsOnlineRazor.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Beneficiary",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    LastName = table.Column<string>(type: "TEXT", nullable: true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: true),
                    MiddleName = table.Column<string>(type: "TEXT", nullable: true),
                    ExtName = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beneficiary", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Region",
                columns: table => new
                {
                    RegionID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Region", x => x.RegionID);
                });

            migrationBuilder.CreateTable(
                name: "Province",
                columns: table => new
                {
                    ProvinceID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    RegionID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Province", x => x.ProvinceID);
                    table.ForeignKey(
                        name: "FK_Province_Region_RegionID",
                        column: x => x.RegionID,
                        principalTable: "Region",
                        principalColumn: "RegionID",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    table.ForeignKey(
                        name: "FK_Municipality_Province_ProvinceID",
                        column: x => x.ProvinceID,
                        principalTable: "Province",
                        principalColumn: "ProvinceID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Barangay",
                columns: table => new
                {
                    BarangayID = table.Column<int>(type: "INTEGER", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    MunicipalityID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barangay", x => x.BarangayID);
                    table.ForeignKey(
                        name: "FK_Barangay_Municipality_MunicipalityID",
                        column: x => x.MunicipalityID,
                        principalTable: "Municipality",
                        principalColumn: "MunicipalityID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Masterlist",
                columns: table => new
                {
                    MasterlistID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BeneficiaryID = table.Column<int>(type: "INTEGER", nullable: false),
                    RegionID = table.Column<int>(type: "INTEGER", nullable: false),
                    ProvinceID = table.Column<int>(type: "INTEGER", nullable: false),
                    MunicipalityID = table.Column<int>(type: "INTEGER", nullable: false),
                    BarangayID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Masterlist", x => x.MasterlistID);
                    table.ForeignKey(
                        name: "FK_Masterlist_Barangay_BarangayID",
                        column: x => x.BarangayID,
                        principalTable: "Barangay",
                        principalColumn: "BarangayID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Masterlist_Beneficiary_BeneficiaryID",
                        column: x => x.BeneficiaryID,
                        principalTable: "Beneficiary",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Masterlist_Municipality_MunicipalityID",
                        column: x => x.MunicipalityID,
                        principalTable: "Municipality",
                        principalColumn: "MunicipalityID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Masterlist_Province_ProvinceID",
                        column: x => x.ProvinceID,
                        principalTable: "Province",
                        principalColumn: "ProvinceID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Masterlist_Region_RegionID",
                        column: x => x.RegionID,
                        principalTable: "Region",
                        principalColumn: "RegionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Barangay_MunicipalityID",
                table: "Barangay",
                column: "MunicipalityID");

            migrationBuilder.CreateIndex(
                name: "IX_Masterlist_BarangayID",
                table: "Masterlist",
                column: "BarangayID");

            migrationBuilder.CreateIndex(
                name: "IX_Masterlist_BeneficiaryID",
                table: "Masterlist",
                column: "BeneficiaryID");

            migrationBuilder.CreateIndex(
                name: "IX_Masterlist_MunicipalityID",
                table: "Masterlist",
                column: "MunicipalityID");

            migrationBuilder.CreateIndex(
                name: "IX_Masterlist_ProvinceID",
                table: "Masterlist",
                column: "ProvinceID");

            migrationBuilder.CreateIndex(
                name: "IX_Masterlist_RegionID",
                table: "Masterlist",
                column: "RegionID");

            migrationBuilder.CreateIndex(
                name: "IX_Municipality_ProvinceID",
                table: "Municipality",
                column: "ProvinceID");

            migrationBuilder.CreateIndex(
                name: "IX_Province_RegionID",
                table: "Province",
                column: "RegionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Masterlist");

            migrationBuilder.DropTable(
                name: "Barangay");

            migrationBuilder.DropTable(
                name: "Beneficiary");

            migrationBuilder.DropTable(
                name: "Municipality");

            migrationBuilder.DropTable(
                name: "Province");

            migrationBuilder.DropTable(
                name: "Region");
        }
    }
}
