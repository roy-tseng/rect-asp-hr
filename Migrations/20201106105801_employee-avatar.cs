using Microsoft.EntityFrameworkCore.Migrations;

namespace rect_asp_hr.Migrations
{
    public partial class employeeavatar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "avatar",
                table: "Employee",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "avatar",
                table: "Employee");
        }
    }
}
