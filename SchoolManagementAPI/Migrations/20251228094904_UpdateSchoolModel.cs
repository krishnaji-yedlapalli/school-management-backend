using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSchoolModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Schools",
                newName: "Timezone");

            migrationBuilder.AddColumn<string>(
                name: "AcademicYear",
                table: "Schools",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AddressLine1",
                table: "Schools",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "AttendanceEnabled",
                table: "Schools",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Board",
                table: "Schools",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Schools",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Schools",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Schools",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Schools",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Schools",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EndTime",
                table: "Schools",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "ExamsEnabled",
                table: "Schools",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "FeesEnabled",
                table: "Schools",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Schools",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MaxStudentsPerSection",
                table: "Schools",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Schools",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Pincode",
                table: "Schools",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RegistrationNumber",
                table: "Schools",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StartTime",
                table: "Schools",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Schools",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "TransportEnabled",
                table: "Schools",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Schools",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AcademicYear",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "AddressLine1",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "AttendanceEnabled",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "Board",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "EndTime",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "ExamsEnabled",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "FeesEnabled",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "MaxStudentsPerSection",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "Pincode",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "RegistrationNumber",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "StartTime",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "TransportEnabled",
                table: "Schools");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Schools");

            migrationBuilder.RenameColumn(
                name: "Timezone",
                table: "Schools",
                newName: "Address");
        }
    }
}
