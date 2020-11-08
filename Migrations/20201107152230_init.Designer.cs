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
    [Migration("20201107152230_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("infolink.rect_asp_hr.Models.Employee", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("avatar")
                        .HasColumnName("avatar")
                        .HasColumnType("text");

                    b.Property<string>("contactAddress")
                        .HasColumnName("contact_address")
                        .HasColumnType("text");

                    b.Property<DateTime?>("dateBirth")
                        .HasColumnName("on_board_birth")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("dateOnBoard")
                        .HasColumnName("on_board_date")
                        .HasColumnType("datetime");

                    b.Property<bool>("gender")
                        .HasColumnName("gender")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("homePhone")
                        .HasColumnName("home_phone")
                        .HasColumnType("text");

                    b.Property<string>("mobilePhone")
                        .HasColumnName("mobile_phone")
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .HasColumnName("name")
                        .HasColumnType("text");

                    b.Property<string>("nationalId")
                        .HasColumnName("national_id")
                        .HasColumnType("text");

                    b.Property<string>("workingNumber")
                        .HasColumnName("working_number")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("Employee");
                });
#pragma warning restore 612, 618
        }
    }
}