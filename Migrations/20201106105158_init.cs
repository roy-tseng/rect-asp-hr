using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.Data.EntityFrameworkCore.Metadata;

namespace rect_asp_hr.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    working_number = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    national_id = table.Column<string>(nullable: true),
                    gender = table.Column<bool>(nullable: false),
                    on_board_date = table.Column<DateTime>(nullable: true),
                    on_board_birth = table.Column<DateTime>(nullable: true),
                    contact_address = table.Column<string>(nullable: true),
                    mobile_phone = table.Column<string>(nullable: true),
                    home_phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");
        }
    }
}
