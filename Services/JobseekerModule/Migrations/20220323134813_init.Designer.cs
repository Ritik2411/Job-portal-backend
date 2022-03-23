﻿// <auto-generated />
using JobseekerModule.context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace JobseekerModule.Migrations
{
    [DbContext(typeof(JobseekerDetailContext))]
    [Migration("20220323134813_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("JobseekerModule.context.Experience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CompanyUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Designation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JobDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("company_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("end_year")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("start_year")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("user_id");

                    b.ToTable("Experience");
                });

            modelBuilder.Entity("JobseekerModule.context.JobSeekerDetail", b =>
                {
                    b.Property<string>("user_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("dob")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("expected_salary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("first_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("last_name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("total_expericence")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("user_id");

                    b.ToTable("JobseekerDetail");
                });

            modelBuilder.Entity("JobseekerModule.context.Qualification", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("grade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("qualification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("university")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("user_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("yearOfCompletion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("user_id");

                    b.ToTable("Qualification");
                });

            modelBuilder.Entity("JobseekerModule.context.Experience", b =>
                {
                    b.HasOne("JobseekerModule.context.JobSeekerDetail", "jobSeeker")
                        .WithMany("experience")
                        .HasForeignKey("user_id");

                    b.Navigation("jobSeeker");
                });

            modelBuilder.Entity("JobseekerModule.context.Qualification", b =>
                {
                    b.HasOne("JobseekerModule.context.JobSeekerDetail", "jobSeeker")
                        .WithMany("qualification")
                        .HasForeignKey("user_id");

                    b.Navigation("jobSeeker");
                });

            modelBuilder.Entity("JobseekerModule.context.JobSeekerDetail", b =>
                {
                    b.Navigation("experience");

                    b.Navigation("qualification");
                });
#pragma warning restore 612, 618
        }
    }
}
