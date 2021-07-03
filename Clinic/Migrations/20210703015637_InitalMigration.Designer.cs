﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Clinic.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210703015637_InitalMigration")]
    partial class InitalMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "6.0.0-preview.5.21301.9");

            modelBuilder.Entity("Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Brown"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Red"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Orange"
                        });
                });

            modelBuilder.Entity("IntakeForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Ailment")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("IntakeForms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ailment = "Lost Arm",
                            DoctorId = 2,
                            PatientId = 1
                        },
                        new
                        {
                            Id = 2,
                            Ailment = "Lost Leg",
                            DoctorId = 1,
                            PatientId = 2
                        },
                        new
                        {
                            Id = 3,
                            Ailment = "Crippling Depression",
                            DoctorId = 3,
                            PatientId = 3
                        });
                });

            modelBuilder.Entity("Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("HealthNumber")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Patients");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "1, Test, dr",
                            DateOfBirth = new DateTime(2021, 7, 2, 20, 56, 36, 651, DateTimeKind.Local).AddTicks(740),
                            HealthNumber = 6436843,
                            Name = "Broccoli",
                            PhoneNumber = "+1 233 12326"
                        },
                        new
                        {
                            Id = 2,
                            Address = "2 Test, Dr",
                            DateOfBirth = new DateTime(2021, 7, 2, 20, 56, 36, 651, DateTimeKind.Local).AddTicks(803),
                            HealthNumber = 6969420,
                            Name = "Carrot",
                            PhoneNumber = "+11 1111 11111"
                        },
                        new
                        {
                            Id = 3,
                            Address = "rum dr, Oklahoma",
                            DateOfBirth = new DateTime(2021, 7, 2, 20, 56, 36, 651, DateTimeKind.Local).AddTicks(810),
                            HealthNumber = 777888999,
                            Name = "Cabbage Patch Girls",
                            PhoneNumber = "+12 1212 123422"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}