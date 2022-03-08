﻿// <auto-generated />
using System;
using EmployeeModule.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmployeeModule.Migrations.VacancyRequests
{
    [DbContext(typeof(VacancyRequestsContext))]
    [Migration("20220308121139_vacancyRequests")]
    partial class vacancyRequests
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("EmployeeModule.Context.VacancyRequests", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("applied_on")
                        .HasColumnType("datetime2");

                    b.Property<string>("user_id")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("vacancy_id")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("vacancyRequests");
                });
#pragma warning restore 612, 618
        }
    }
}
