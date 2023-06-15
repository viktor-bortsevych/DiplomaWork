using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DiplomaWork.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDataToEntitiesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Classrooms",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { "classroom-id-1", "Classroom 1" },
                    { "classroom-id-2", "Classroom 2" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { "subject-id-1", "Math" },
                    { "subject-id-2", "Science" }
                });

            migrationBuilder.InsertData(
                table: "Teachers",
                columns: new[] { "Id", "FirstName", "LastName", "SecondName" },
                values: new object[,]
                {
                    { "teacher-id-1", "John", "Doe", null },
                    { "teacher-id-2", "Jane", "Smith", null }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "ID", "Name", "TeacherID" },
                values: new object[,]
                {
                    { "group-id-1", "Group A", "teacher-id-1" },
                    { "group-id-2", "Group B", "teacher-id-2" }
                });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "ID", "ClassroomID", "DayOfWeek", "GroupID", "Number", "SubjectID", "TeacherID" },
                values: new object[,]
                {
                    { "5d84fbfb-40d9-4bda-9f4a-ec609e8c76e8", "classroom-id-2", 2, "group-id-2", 2, "subject-id-2", "teacher-id-2" },
                    { "6b81a824-44e0-46e6-9710-dcfcc175b6a1", "classroom-id-1", 1, "group-id-1", 1, "subject-id-1", "teacher-id-1" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "ID",
                keyValue: "5d84fbfb-40d9-4bda-9f4a-ec609e8c76e8");

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "ID",
                keyValue: "6b81a824-44e0-46e6-9710-dcfcc175b6a1");

            migrationBuilder.DeleteData(
                table: "Classrooms",
                keyColumn: "ID",
                keyValue: "classroom-id-1");

            migrationBuilder.DeleteData(
                table: "Classrooms",
                keyColumn: "ID",
                keyValue: "classroom-id-2");

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "ID",
                keyValue: "group-id-1");

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "ID",
                keyValue: "group-id-2");

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "ID",
                keyValue: "subject-id-1");

            migrationBuilder.DeleteData(
                table: "Subjects",
                keyColumn: "ID",
                keyValue: "subject-id-2");

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: "teacher-id-1");

            migrationBuilder.DeleteData(
                table: "Teachers",
                keyColumn: "Id",
                keyValue: "teacher-id-2");
        }
    }
}
