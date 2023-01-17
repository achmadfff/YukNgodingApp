using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YukNgodingLivecode.Migrations
{
    /// <inheritdoc />
    public partial class Teacher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "trainer",
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
                name: "trainer",
                schema: "dbo",
                table: "courses");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "dbo",
                table: "trainees",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
