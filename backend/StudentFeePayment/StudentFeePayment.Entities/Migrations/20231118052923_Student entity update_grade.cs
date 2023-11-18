using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentFeePayment.Entities.Migrations
{
    /// <inheritdoc />
    public partial class Studententityupdate_grade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Grade",
                schema: "school",
                table: "Student",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Grade",
                schema: "school",
                table: "Student");
        }
    }
}
