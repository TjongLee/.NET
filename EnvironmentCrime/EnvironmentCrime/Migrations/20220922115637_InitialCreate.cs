using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EnvironmentCrime.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "departments",
                columns: table => new
                {
                    DepartmentId = table.Column<string>(nullable: false),
                    DepartmentName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    EmployeeId = table.Column<string>(nullable: false),
                    EmployeeName = table.Column<string>(nullable: true),
                    RoleTitle = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "errands",
                columns: table => new
                {
                    ErrandId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefNumber = table.Column<string>(nullable: true),
                    Place = table.Column<string>(nullable: false),
                    TypeOfCrime = table.Column<string>(nullable: false),
                    DateOfObservation = table.Column<DateTime>(nullable: false),
                    Observation = table.Column<string>(nullable: true),
                    InvestigatorInfo = table.Column<string>(nullable: true),
                    InvestigatorAction = table.Column<string>(nullable: true),
                    InformerName = table.Column<string>(nullable: false),
                    InformerPhone = table.Column<string>(nullable: false),
                    StatusId = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_errands", x => x.ErrandId);
                });

            migrationBuilder.CreateTable(
                name: "errandStatuses",
                columns: table => new
                {
                    StatusId = table.Column<string>(nullable: false),
                    StatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_errandStatuses", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "pictures",
                columns: table => new
                {
                    PictureId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PictureName = table.Column<string>(nullable: true),
                    ErrandId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pictures", x => x.PictureId);
                });

            migrationBuilder.CreateTable(
                name: "sequences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentValue = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sequences", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "departments");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "errands");

            migrationBuilder.DropTable(
                name: "errandStatuses");

            migrationBuilder.DropTable(
                name: "pictures");

            migrationBuilder.DropTable(
                name: "sequences");
        }
    }
}
