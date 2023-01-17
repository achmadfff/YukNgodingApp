using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YukNgodingLivecode.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "courses",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "NVarchar(100)", nullable: false),
                    description = table.Column<string>(type: "NVarchar(100)", nullable: false),
                    coursetime = table.Column<string>(name: "course_time", type: "NVarchar(100)", nullable: false),
                    costcategory = table.Column<string>(name: "cost_category", type: "NVarchar(100)", nullable: false),
                    coursecategory = table.Column<string>(name: "course_category", type: "NVarchar(100)", nullable: false),
                    mincriteria = table.Column<int>(name: "min_criteria", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "trainees",
                schema: "dbo",
                columns: table => new
                {
                    email = table.Column<string>(type: "NVarchar(100)", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstname = table.Column<string>(name: "first_name", type: "NVarchar(100)", nullable: false),
                    lastname = table.Column<string>(name: "last_name", type: "NVarchar(100)", nullable: false),
                    callname = table.Column<string>(name: "call_name", type: "NVarchar(100)", nullable: false),
                    domicileaddress = table.Column<string>(name: "domicile_address", type: "NVarchar(100)", nullable: false),
                    phonenumber = table.Column<string>(name: "phone_number", type: "NVarchar(14)", nullable: false),
                    nik = table.Column<int>(type: "int", nullable: false),
                    lasteducation = table.Column<string>(name: "last_education", type: "NVarchar(14)", nullable: false),
                    isactive = table.Column<bool>(name: "is_active", type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trainees", x => x.email);
                });

            migrationBuilder.CreateTable(
                name: "course_details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    starttime = table.Column<string>(name: "start_time", type: "NVarchar(100)", nullable: false),
                    endtime = table.Column<string>(name: "end_time", type: "NVarchar(100)", nullable: false),
                    startdate = table.Column<string>(name: "start_date", type: "NVarchar(100)", nullable: false),
                    enddate = table.Column<string>(name: "end_date", type: "NVarchar(100)", nullable: false),
                    traineeid = table.Column<int>(name: "trainee_id", type: "int", nullable: false),
                    isapprove = table.Column<bool>(name: "is_approve", type: "bit", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    TraineeEmail = table.Column<string>(type: "NVarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course_details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_course_details_courses_CourseId",
                        column: x => x.CourseId,
                        principalSchema: "dbo",
                        principalTable: "courses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_course_details_trainees_TraineeEmail",
                        column: x => x.TraineeEmail,
                        principalSchema: "dbo",
                        principalTable: "trainees",
                        principalColumn: "email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "credentials",
                schema: "dbo",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "NVarchar(100)", nullable: false),
                    password = table.Column<string>(type: "NVarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_credentials", x => x.id);
                    table.ForeignKey(
                        name: "FK_credentials_trainees_email",
                        column: x => x.email,
                        principalSchema: "dbo",
                        principalTable: "trainees",
                        principalColumn: "email",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_course_details_CourseId",
                table: "course_details",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_course_details_TraineeEmail",
                table: "course_details",
                column: "TraineeEmail");

            migrationBuilder.CreateIndex(
                name: "IX_credentials_email",
                schema: "dbo",
                table: "credentials",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_trainees_email",
                schema: "dbo",
                table: "trainees",
                column: "email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_trainees_nik",
                schema: "dbo",
                table: "trainees",
                column: "nik",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_trainees_phone_number",
                schema: "dbo",
                table: "trainees",
                column: "phone_number",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "course_details");

            migrationBuilder.DropTable(
                name: "credentials",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "courses",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "trainees",
                schema: "dbo");
        }
    }
}
