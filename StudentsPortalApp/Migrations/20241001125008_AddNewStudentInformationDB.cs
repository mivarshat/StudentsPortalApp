using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentsPortalApp.Migrations
{
    /// <inheritdoc />
    public partial class AddNewStudentInformationDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentCurriculamDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RollNo = table.Column<int>(type: "int", nullable: false),
                    Class = table.Column<int>(type: "int", nullable: false),
                    MathsMarks = table.Column<int>(type: "int", nullable: false),
                    ScienceMarks = table.Column<int>(type: "int", nullable: false),
                    EnglishMarks = table.Column<int>(type: "int", nullable: false),
                    SSTMarks = table.Column<int>(type: "int", nullable: false),
                    MarathiMarks = table.Column<int>(type: "int", nullable: false),
                    HindiMarks = table.Column<int>(type: "int", nullable: false),
                    ComputerMarks = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCurriculamDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentPersonalDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RollNo = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Class = table.Column<int>(type: "int", nullable: false),
                    Division = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentPersonalDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RollNo = table.Column<int>(type: "int", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    StudentName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentRecords", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "StudentCurriculamDetails");

            migrationBuilder.DropTable(
                name: "StudentPersonalDetails");

            migrationBuilder.DropTable(
                name: "StudentRecords");
        }
    }
}
