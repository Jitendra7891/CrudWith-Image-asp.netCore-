using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DotNet5Crud.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    EmployeeSalary = table.Column<double>(type: "float", unicode: false, maxLength: 250, nullable: false),
                    EmployeeCity = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: false),
                    Image = table.Column<byte[]>(type: "varbinary(1000)", unicode: false, maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
