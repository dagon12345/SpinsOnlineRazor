using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpinsOnlineRazor.Migrations
{
    /// <inheritdoc />
    public partial class AddedValidationForm : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ValidationformID",
                table: "Masterlist",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Beneficiary",
                type: "TEXT",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Beneficiary",
                type: "TEXT",
                maxLength: 20,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Validationform",
                columns: table => new
                {
                    ValidationformID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AssessmentID = table.Column<int>(type: "INTEGER", nullable: false),
                    ReferenceCode = table.Column<int>(type: "INTEGER", nullable: false),
                    SpinsBatch = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Validationform", x => x.ValidationformID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Masterlist_ValidationformID",
                table: "Masterlist",
                column: "ValidationformID");

            migrationBuilder.AddForeignKey(
                name: "FK_Masterlist_Validationform_ValidationformID",
                table: "Masterlist",
                column: "ValidationformID",
                principalTable: "Validationform",
                principalColumn: "ValidationformID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Masterlist_Validationform_ValidationformID",
                table: "Masterlist");

            migrationBuilder.DropTable(
                name: "Validationform");

            migrationBuilder.DropIndex(
                name: "IX_Masterlist_ValidationformID",
                table: "Masterlist");

            migrationBuilder.DropColumn(
                name: "ValidationformID",
                table: "Masterlist");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Beneficiary",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Beneficiary",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldMaxLength: 20);
        }
    }
}
