﻿// <auto-generated />
using System;
using Aps.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Aps.Repository.Migrations
{
    [DbContext(typeof(ApsContext))]
    [Migration("20190524123141_CreateRelationShip")]
    partial class CreateRelationShip
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Aps.Domain.Discipline", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int?>("StudentId");

                    b.Property<int?>("TeacherID");

                    b.HasKey("Id");

                    b.HasIndex("StudentId");

                    b.HasIndex("TeacherID");

                    b.ToTable("Disciplines");
                });

            modelBuilder.Entity("Aps.Domain.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Class");

                    b.Property<string>("Name");

                    b.Property<string>("Registration");

                    b.Property<int>("Term");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("Aps.Domain.Teacher", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Registration");

                    b.HasKey("Id");

                    b.ToTable("Teachers");
                });

            modelBuilder.Entity("Aps.Domain.Discipline", b =>
                {
                    b.HasOne("Aps.Domain.Student")
                        .WithMany("Disciplines")
                        .HasForeignKey("StudentId");

                    b.HasOne("Aps.Domain.Teacher", "Teacher")
                        .WithMany()
                        .HasForeignKey("TeacherID");
                });
#pragma warning restore 612, 618
        }
    }
}
