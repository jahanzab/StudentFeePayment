using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StudentFeePayment.Entities.Migrations
{
    /// <inheritdoc />
    public partial class runcontextmigrationandseeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "school");

            migrationBuilder.CreateTable(
                name: "Student",
                schema: "school",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StudentNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeePayment",
                schema: "school",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FeeAmount = table.Column<decimal>(type: "decimal(16,2)", precision: 16, scale: 2, nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    PaidDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FeeYear = table.Column<int>(type: "int", nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeePayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeePayment_Student_StudentId",
                        column: x => x.StudentId,
                        principalSchema: "school",
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "school",
                table: "Student",
                columns: new[] { "Id", "Address", "CreatedBy", "CreatedDate", "DOB", "Email", "FirstName", "Grade", "LastName", "Phone", "StudentNumber", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Islamabad, Pakistan", "system user", new DateTime(2023, 11, 19, 18, 5, 26, 322, DateTimeKind.Local).AddTicks(8581), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "jahanzab@live.com", "Jahnzab", "First", "Ashraf", "+92 334 6168078", "00001", "system user", new DateTime(2023, 11, 19, 18, 5, 26, 322, DateTimeKind.Local).AddTicks(8592) },
                    { 2, "NY, USA", "system user", new DateTime(2023, 11, 19, 18, 5, 26, 322, DateTimeKind.Local).AddTicks(8595), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@live.com", "John", "Second", "Doe", "+1 (555) 555-1234", "00002", "system user", new DateTime(2023, 11, 19, 18, 5, 26, 322, DateTimeKind.Local).AddTicks(8595) }
                });

            migrationBuilder.InsertData(
                schema: "school",
                table: "FeePayment",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "FeeAmount", "FeeYear", "IsPaid", "PaidDate", "Remarks", "StudentId", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "system user", new DateTime(2023, 11, 19, 18, 5, 26, 322, DateTimeKind.Local).AddTicks(8632), 102.21m, 2023, true, new DateTime(2023, 11, 19, 18, 5, 26, 322, DateTimeKind.Local).AddTicks(8631), "Fee paid", 1, "system user", new DateTime(2023, 11, 19, 18, 5, 26, 322, DateTimeKind.Local).AddTicks(8632) },
                    { 2, "system user", new DateTime(2023, 11, 19, 18, 5, 26, 322, DateTimeKind.Local).AddTicks(8634), 90.50m, 2023, true, new DateTime(2023, 11, 19, 18, 5, 26, 322, DateTimeKind.Local).AddTicks(8634), "Fee paid", 2, "system user", new DateTime(2023, 11, 19, 18, 5, 26, 322, DateTimeKind.Local).AddTicks(8635) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FeePayment_StudentId",
                schema: "school",
                table: "FeePayment",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Student_StudentNumber",
                schema: "school",
                table: "Student",
                column: "StudentNumber",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FeePayment",
                schema: "school");

            migrationBuilder.DropTable(
                name: "Student",
                schema: "school");
        }
    }
}
