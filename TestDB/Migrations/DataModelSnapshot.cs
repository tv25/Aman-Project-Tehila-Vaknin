﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestDB.DATA;

#nullable disable

namespace TestDB.Migrations
{
    [DbContext(typeof(Data))]
    partial class DataModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0-preview.3.23174.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TestDB.Models.CoronaDetails", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<DateTime?>("RecoveryDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("StartCoronaDate")
                        .HasColumnType("datetime2");

                    b.HasKey("id");

                    b.ToTable("CoronaDetails");
                });

            modelBuilder.Entity("TestDB.Models.DetailVacsions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CoronaDetailsid")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("manufacturer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CoronaDetailsid");

                    b.ToTable("DetailVacsions");
                });

            modelBuilder.Entity("TestDB.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CoronaDetailsid")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MobilePhone")
                        .HasColumnType("int");

                    b.Property<int?>("Number_Home")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Telephone")
                        .HasColumnType("int");

                    b.Property<int>("id_Patient")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CoronaDetailsid");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("TestDB.Models.DetailVacsions", b =>
                {
                    b.HasOne("TestDB.Models.CoronaDetails", null)
                        .WithMany("dateAndmanufacturer")
                        .HasForeignKey("CoronaDetailsid");
                });

            modelBuilder.Entity("TestDB.Models.Patient", b =>
                {
                    b.HasOne("TestDB.Models.CoronaDetails", "CoronaDetails")
                        .WithMany()
                        .HasForeignKey("CoronaDetailsid");

                    b.Navigation("CoronaDetails");
                });

            modelBuilder.Entity("TestDB.Models.CoronaDetails", b =>
                {
                    b.Navigation("dateAndmanufacturer");
                });
#pragma warning restore 612, 618
        }
    }
}
