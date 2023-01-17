﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YukNgoding_Livecode.Repository;

#nullable disable

namespace YukNgodingLivecode.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230117051817_StartTime")]
    partial class StartTime
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("YukNgoding_Livecode.Entities.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CostCategory")
                        .IsRequired()
                        .HasColumnType("NVarchar(100)")
                        .HasColumnName("cost_category");

                    b.Property<string>("CourseCategory")
                        .IsRequired()
                        .HasColumnType("NVarchar(100)")
                        .HasColumnName("course_category");

                    b.Property<string>("CourseTime")
                        .IsRequired()
                        .HasColumnType("NVarchar(100)")
                        .HasColumnName("course_time");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("NVarchar(100)")
                        .HasColumnName("description");

                    b.Property<string>("EndTime")
                        .IsRequired()
                        .HasColumnType("NVarchar(100)")
                        .HasColumnName("end_time");

                    b.Property<int>("MinCriteria")
                        .HasColumnType("int")
                        .HasColumnName("min_criteria");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVarchar(100)")
                        .HasColumnName("name");

                    b.Property<string>("StartTime")
                        .IsRequired()
                        .HasColumnType("NVarchar(100)")
                        .HasColumnName("start_time");

                    b.Property<string>("Trainer")
                        .IsRequired()
                        .HasColumnType("NVarchar(100)")
                        .HasColumnName("trainer");

                    b.HasKey("Id");

                    b.ToTable("courses", "dbo");
                });

            modelBuilder.Entity("YukNgoding_Livecode.Entities.CourseDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("end_date");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("is_approve");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("start_date");

                    b.Property<string>("TraineeEmail")
                        .IsRequired()
                        .HasColumnType("NVarchar(100)");

                    b.Property<int>("TraineeId")
                        .HasColumnType("int")
                        .HasColumnName("trainee_id");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("TraineeEmail");

                    b.ToTable("course_details");
                });

            modelBuilder.Entity("YukNgoding_Livecode.Entities.Credential", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVarchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("NVarchar(50)")
                        .HasColumnName("password");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("credentials", "dbo");
                });

            modelBuilder.Entity("YukNgoding_Livecode.Entities.Trainee", b =>
                {
                    b.Property<string>("Email")
                        .HasColumnType("NVarchar(100)")
                        .HasColumnName("email");

                    b.Property<string>("CallName")
                        .IsRequired()
                        .HasColumnType("NVarchar(100)")
                        .HasColumnName("call_name");

                    b.Property<string>("DomicileAddress")
                        .IsRequired()
                        .HasColumnType("NVarchar(100)")
                        .HasColumnName("domicile_address");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("NVarchar(100)")
                        .HasColumnName("first_name");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit")
                        .HasColumnName("is_active");

                    b.Property<string>("LastEducation")
                        .IsRequired()
                        .HasColumnType("NVarchar(14)")
                        .HasColumnName("last_education");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("NVarchar(100)")
                        .HasColumnName("last_name");

                    b.Property<int>("Nik")
                        .HasColumnType("int")
                        .HasColumnName("nik");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("NVarchar(14)")
                        .HasColumnName("phone_number");

                    b.HasKey("Email");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Nik")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.ToTable("trainees", "dbo");
                });

            modelBuilder.Entity("YukNgoding_Livecode.Entities.CourseDetail", b =>
                {
                    b.HasOne("YukNgoding_Livecode.Entities.Course", "Course")
                        .WithMany("CourseDetails")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("YukNgoding_Livecode.Entities.Trainee", "Trainee")
                        .WithMany("CourseDetails")
                        .HasForeignKey("TraineeEmail")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Trainee");
                });

            modelBuilder.Entity("YukNgoding_Livecode.Entities.Credential", b =>
                {
                    b.HasOne("YukNgoding_Livecode.Entities.Trainee", "Trainee")
                        .WithOne("Credential")
                        .HasForeignKey("YukNgoding_Livecode.Entities.Credential", "Email")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trainee");
                });

            modelBuilder.Entity("YukNgoding_Livecode.Entities.Course", b =>
                {
                    b.Navigation("CourseDetails");
                });

            modelBuilder.Entity("YukNgoding_Livecode.Entities.Trainee", b =>
                {
                    b.Navigation("CourseDetails");

                    b.Navigation("Credential")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
