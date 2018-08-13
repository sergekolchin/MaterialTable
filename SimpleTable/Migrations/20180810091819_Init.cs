using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleTable.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    Gender = table.Column<int>(nullable: false),
                    IsCertified = table.Column<bool>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    DepartmentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Production" },
                    { 2, "Research and Development" },
                    { 3, "Purchasing" },
                    { 4, "Marketing" },
                    { 5, "Human Resource Management" },
                    { 6, "Accounting" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "BirthDate", "DepartmentId", "Email", "FirstName", "Gender", "IsCertified", "LastName", "Phone" },
                values: new object[,]
                {
                    { 10, new DateTime(1980, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "kkubacek9@ed.gov", "Kaylil", 1, false, "Kubacek", "86 209 214 4933" },
                    { 2, new DateTime(1998, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "fpersich1@hibu.com", "Francyne", 1, false, "Persich", "62 196 534 2823" },
                    { 7, new DateTime(1990, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "dlankford6@ehow.com", "Devlin", 0, false, "Lankford", "34 794 445 7780" },
                    { 8, new DateTime(1970, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "hbenedyktowicz7@barnesandnoble.com", "Halie", 1, true, "Benedyktowicz", "1 304 498 6560" },
                    { 4, new DateTime(1991, 3, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "cwhalley3@yellowbook.com", "Clayson", 0, false, "Whalley", "1 149 158 3062" },
                    { 3, new DateTime(1977, 1, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "hcarlin2@google.ca", "Hugo", 0, true, "Carlin", "86 410 472 9880" },
                    { 1, new DateTime(1997, 8, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "cvicarey0@rambler.ru", "Cleveland", 0, false, "Vicarey", "51 523 699 9284" },
                    { 5, new DateTime(1993, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "fclemitt4@wordpress.com", "Fairleigh", 0, false, "Clemitt", "44 276 410 3141" },
                    { 6, new DateTime(1999, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "eregler5@seesaa.net", "Erastus", 0, true, "Regler", "962 309 299 2461" },
                    { 9, new DateTime(1994, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "rwrassell8@samsung.com", "Ransell", 0, false, "Wrassell", "591 244 781 3894" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
