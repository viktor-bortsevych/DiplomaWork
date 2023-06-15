using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DiplomaWork.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAllEntitiesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classrooms",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classrooms", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TeacherID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Groups_Teachers_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teachers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Lessons",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    SubjectID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    TeacherID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    ClassroomID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    GroupID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessons", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Lessons_Classrooms_ClassroomID",
                        column: x => x.ClassroomID,
                        principalTable: "Classrooms",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Lessons_Groups_GroupID",
                        column: x => x.GroupID,
                        principalTable: "Groups",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Lessons_Subjects_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_Lessons_Teachers_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teachers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classrooms_Name",
                table: "Classrooms",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_Name",
                table: "Groups",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Groups_TeacherID",
                table: "Groups",
                column: "TeacherID",
                unique: true,
                filter: "[TeacherID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_ClassroomID",
                table: "Lessons",
                column: "ClassroomID",
                unique: true,
                filter: "[ClassroomID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_DayOfWeek_Number_GroupID",
                table: "Lessons",
                columns: new[] { "DayOfWeek", "Number", "GroupID" },
                unique: true,
                filter: "[GroupID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_GroupID",
                table: "Lessons",
                column: "GroupID",
                unique: true,
                filter: "[GroupID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_SubjectID",
                table: "Lessons",
                column: "SubjectID",
                unique: true,
                filter: "[SubjectID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Lessons_TeacherID",
                table: "Lessons",
                column: "TeacherID",
                unique: true,
                filter: "[TeacherID] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_FirstName_LastName",
                table: "Teachers",
                columns: new[] { "FirstName", "LastName" },
                unique: true,
                filter: "[LastName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lessons");

            migrationBuilder.DropTable(
                name: "Classrooms");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Teachers");
        }
    }
}
