﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using infolink.rect_asp_hr.Models;

namespace rect_asp_hr.Migrations
{
    [DbContext(typeof(MySQLContext))]
    [Migration("20201113135827_1st")]
    partial class _1st
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("infolink.rect_asp_hr.Models.Employee", b =>
                {
                    b.Property<string>("workingNumber")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4")
                        .HasColumnName("working_number");

                    b.Property<string>("avatar")
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("avatar");

                    b.Property<string>("contactAddress")
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("contact_address");

                    b.Property<DateTime?>("createTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("create_time");

                    b.Property<DateTime?>("dateBirth")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("on_board_birth");

                    b.Property<DateTime?>("dateOnBoard")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("on_board_date");

                    b.Property<bool>("gender")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("gender");

                    b.Property<string>("homePhone")
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("home_phone");

                    b.Property<string>("mobilePhone")
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("mobile_phone");

                    b.Property<string>("name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("name");

                    b.Property<string>("nationalId")
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("national_id");

                    b.Property<DateTime?>("updateTime")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("update_time");

                    b.HasKey("workingNumber");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("infolink.rect_asp_hr.Models.Geneder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("code")
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("code");

                    b.Property<string>("name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("type");

                    b.HasKey("Id");

                    b.ToTable("Gender");
                });
#pragma warning restore 612, 618
        }
    }
}
