﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebRoster.Data;

#nullable disable

namespace WebRoster.Data.Migrations
{
    [DbContext(typeof(RosterContext))]
    [Migration("20241024015844_multipleupdates")]
    partial class multipleupdates
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebRoster.Models.Course", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CourseName = "Math"
                        },
                        new
                        {
                            ID = 2,
                            CourseName = "Science"
                        });
                });

            modelBuilder.Entity("WebRoster.Models.CourseInstructor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<int>("InstructorID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CourseID");

                    b.HasIndex("InstructorID");

                    b.ToTable("CourseInstructors");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CourseID = 1,
                            InstructorID = 2
                        },
                        new
                        {
                            ID = 2,
                            CourseID = 2,
                            InstructorID = 2
                        });
                });

            modelBuilder.Entity("WebRoster.Models.CourseStudent", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CourseID")
                        .HasColumnType("int");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CourseID");

                    b.HasIndex("StudentID");

                    b.ToTable("CourseStudents");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            CourseID = 1,
                            StudentID = 3
                        });
                });

            modelBuilder.Entity("WebRoster.Models.Role", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            RoleName = "Teacher"
                        },
                        new
                        {
                            ID = 2,
                            RoleName = "Student"
                        });
                });

            modelBuilder.Entity("WebRoster.Models.User", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("RoleID");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            FirstName = "teacher1",
                            LastName = "teacher1",
                            Password = "hashedpassword1",
                            RoleID = 1,
                            UserName = "teacher1"
                        },
                        new
                        {
                            ID = 2,
                            FirstName = "teacher2",
                            LastName = "teacher2",
                            Password = "hashedpassword2",
                            RoleID = 1,
                            UserName = "teacher2"
                        },
                        new
                        {
                            ID = 3,
                            FirstName = "student1",
                            LastName = "student1",
                            Password = "hashedpassword3",
                            RoleID = 2,
                            UserName = "student1"
                        });
                });

            modelBuilder.Entity("WebRoster.Models.UserDetail", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("UserID")
                        .IsUnique();

                    b.ToTable("UserDetails");
                });

            modelBuilder.Entity("WebRoster.Models.CourseInstructor", b =>
                {
                    b.HasOne("WebRoster.Models.Course", "Course")
                        .WithMany("CourseInstructors")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebRoster.Models.User", "Instructor")
                        .WithMany("CourseInstructors")
                        .HasForeignKey("InstructorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("WebRoster.Models.CourseStudent", b =>
                {
                    b.HasOne("WebRoster.Models.Course", "Course")
                        .WithMany("CourseStudents")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebRoster.Models.User", "Student")
                        .WithMany("CourseStudents")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("WebRoster.Models.User", b =>
                {
                    b.HasOne("WebRoster.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("WebRoster.Models.UserDetail", b =>
                {
                    b.HasOne("WebRoster.Models.User", "User")
                        .WithOne("UserDetail")
                        .HasForeignKey("WebRoster.Models.UserDetail", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebRoster.Models.Course", b =>
                {
                    b.Navigation("CourseInstructors");

                    b.Navigation("CourseStudents");
                });

            modelBuilder.Entity("WebRoster.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("WebRoster.Models.User", b =>
                {
                    b.Navigation("CourseInstructors");

                    b.Navigation("CourseStudents");

                    b.Navigation("UserDetail")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
