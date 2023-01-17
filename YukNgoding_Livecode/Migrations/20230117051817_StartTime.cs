using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YukNgodingLivecode.Migrations
{
    /// <inheritdoc />
    public partial class StartTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "end_time",
                table: "course_details");

            migrationBuilder.DropColumn(
                name: "start_time",
                table: "course_details");

            migrationBuilder.AddColumn<string>(
                name: "end_time",
                schema: "dbo",
                table: "courses",
                type: "NVarchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "start_time",
                schema: "dbo",
                table: "courses",
                type: "NVarchar(100)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "end_time",
                schema: "dbo",
                table: "courses");

            migrationBuilder.DropColumn(
                name: "start_time",
                schema: "dbo",
                table: "courses");

            migrationBuilder.AddColumn<string>(
                name: "end_time",
                table: "course_details",
                type: "NVarchar(100)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "start_time",
                table: "course_details",
                type: "NVarchar(100)",
                nullable: false,
                defaultValue: "");
        }
    }
}
