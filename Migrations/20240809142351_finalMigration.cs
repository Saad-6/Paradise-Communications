using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Paradise.Migrations
{
    /// <inheritdoc />
    public partial class finalMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "MVA");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Medicare");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "AutoInsurance");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "BasicInfo",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfSubmission",
                table: "BasicInfo",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "BasicInfo");

            migrationBuilder.DropColumn(
                name: "DateOfSubmission",
                table: "BasicInfo");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "MVA",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Medicare",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "AutoInsurance",
                type: "datetime2",
                nullable: true);
        }
    }
}
