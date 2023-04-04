using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMS.Entity.Migrations
{
    public partial class Second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "attandance",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    employeeid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    timein = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    timeout = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    remarks = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attandance", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "department",
                columns: table => new
                {
                    deptid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    deptname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isdeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_department", x => x.deptid);
                });

            migrationBuilder.CreateTable(
                name: "employee",
                columns: table => new
                {
                    employeeid = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mobile = table.Column<long>(type: "bigint", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dob = table.Column<DateTime>(type: "datetime2", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    departmentid = table.Column<int>(type: "int", nullable: false),
                    positionid = table.Column<int>(type: "int", nullable: false),
                    salaryid = table.Column<int>(type: "int", nullable: false),
                    isdeleted = table.Column<bool>(type: "bit", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employee", x => x.employeeid);
                });

            migrationBuilder.CreateTable(
                name: "leave",
                columns: table => new
                {
                    leaveid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    leavename = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    days = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leave", x => x.leaveid);
                });

            migrationBuilder.CreateTable(
                name: "leave_application",
                columns: table => new
                {
                    leaveapplyid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    leaveid = table.Column<int>(type: "int", nullable: false),
                    employeeid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    startdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    enddate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    leavedays = table.Column<int>(type: "int", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dateapplied = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_leave_application", x => x.leaveapplyid);
                });

            migrationBuilder.CreateTable(
                name: "position",
                columns: table => new
                {
                    positionid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    positionname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    isdeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_position", x => x.positionid);
                });

            migrationBuilder.CreateTable(
                name: "project",
                columns: table => new
                {
                    projectid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    projectname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    startdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    enddate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project", x => x.projectid);
                });

            migrationBuilder.CreateTable(
                name: "project_allocation",
                columns: table => new
                {
                    allocationid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    projectid = table.Column<int>(type: "int", nullable: false),
                    employeeid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    allocationdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_project_allocation", x => x.allocationid);
                });

            migrationBuilder.CreateTable(
                name: "salary",
                columns: table => new
                {
                    salaryid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    salary = table.Column<int>(type: "int", nullable: false),
                    pf = table.Column<int>(type: "int", nullable: false),
                    specialallowance = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_salary", x => x.salaryid);
                });

            migrationBuilder.CreateTable(
                name: "training",
                columns: table => new
                {
                    trainingid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    trainingname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_training", x => x.trainingid);
                });

            migrationBuilder.CreateTable(
                name: "training_allocation",
                columns: table => new
                {
                    trainingallocationid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    trainingid = table.Column<int>(type: "int", nullable: false),
                    employeeid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_training_allocation", x => x.trainingallocationid);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "attandance");

            migrationBuilder.DropTable(
                name: "department");

            migrationBuilder.DropTable(
                name: "employee");

            migrationBuilder.DropTable(
                name: "leave");

            migrationBuilder.DropTable(
                name: "leave_application");

            migrationBuilder.DropTable(
                name: "position");

            migrationBuilder.DropTable(
                name: "project");

            migrationBuilder.DropTable(
                name: "project_allocation");

            migrationBuilder.DropTable(
                name: "salary");

            migrationBuilder.DropTable(
                name: "training");

            migrationBuilder.DropTable(
                name: "training_allocation");
        }
    }
}
