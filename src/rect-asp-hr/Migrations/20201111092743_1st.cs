﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace rect_asp_hr.Migrations
{
    public partial class _1st : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    working_number = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    national_id = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    gender = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    on_board_date = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    on_board_birth = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    contact_address = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    mobile_phone = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    home_phone = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    avatar = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    type = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Gender");
        }
    }
}
