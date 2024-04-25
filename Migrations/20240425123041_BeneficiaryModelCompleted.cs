using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SpinsOnlineRazor.Migrations
{
    /// <inheritdoc />
    public partial class BeneficiaryModelCompleted : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "SpinsBatch",
                table: "Validationform",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateEntered",
                table: "Beneficiary",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeceasedDate",
                table: "Beneficiary",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Beneficiary",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Beneficiary",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EnteredBy",
                table: "Beneficiary",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExclusionBatch",
                table: "Beneficiary",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExclusionDate",
                table: "Beneficiary",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "InclusionDate",
                table: "Beneficiary",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Beneficiary",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Beneficiary",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Beneficiary",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateEntered",
                table: "Beneficiary");

            migrationBuilder.DropColumn(
                name: "DeceasedDate",
                table: "Beneficiary");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Beneficiary");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Beneficiary");

            migrationBuilder.DropColumn(
                name: "EnteredBy",
                table: "Beneficiary");

            migrationBuilder.DropColumn(
                name: "ExclusionBatch",
                table: "Beneficiary");

            migrationBuilder.DropColumn(
                name: "ExclusionDate",
                table: "Beneficiary");

            migrationBuilder.DropColumn(
                name: "InclusionDate",
                table: "Beneficiary");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Beneficiary");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Beneficiary");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Beneficiary");

            migrationBuilder.AlterColumn<int>(
                name: "SpinsBatch",
                table: "Validationform",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }
    }
}
