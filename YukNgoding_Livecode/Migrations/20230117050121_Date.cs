using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YukNgodingLivecode.Migrations
{
    /// <inheritdoc />
    public partial class Date : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "start_date",
                table: "course_details",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVarchar(100)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "end_date",
                table: "course_details",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVarchar(100)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "start_date",
                table: "course_details",
                type: "NVarchar(100)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "end_date",
                table: "course_details",
                type: "NVarchar(100)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
