﻿// <auto-generated />
using System;
using BusinessLib.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BusinessLib.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240825132439_Initiate")]
    partial class Initiate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domains.Models.TbCountry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TbCountries");
                });

            modelBuilder.Entity("Domains.Models.TbPerson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("Birthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<int>("CreatedByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PractitionerId")
                        .HasColumnType("int");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TbCountryId")
                        .HasColumnType("int");

                    b.Property<string>("ThirdName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UpdateByUserId")
                        .HasColumnType("int");

                    b.Property<int?>("UpdateDate")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PractitionerId")
                        .IsUnique();

                    b.HasIndex("TbCountryId");

                    b.ToTable("TbPeople");
                });

            modelBuilder.Entity("Domains.Models.TbPractitioner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int?>("PractitionerSpecId")
                        .HasColumnType("int");

                    b.Property<string>("PractitionerType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TbPractitioners", (string)null);
                });

            modelBuilder.Entity("Domains.Models.TbPractitionerSpec", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<byte?>("ExpertSubscriptionType")
                        .HasColumnType("tinyint");

                    b.Property<byte?>("ExpertSubscriptionWay")
                        .HasColumnType("tinyint");

                    b.Property<byte?>("JudgerSubscriptionType")
                        .HasColumnType("tinyint");

                    b.Property<byte?>("JudgerSubscriptionWay")
                        .HasColumnType("tinyint");

                    b.Property<int>("PractitionerId")
                        .HasColumnType("int");

                    b.Property<string>("RegulatorMembershipNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte?>("RegulatorSubscriptionType")
                        .HasColumnType("tinyint");

                    b.Property<byte?>("RegulatorSubscriptionWay")
                        .HasColumnType("tinyint");

                    b.Property<string>("ShariaLicenseNubmer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte?>("ShariaSubscriptionType")
                        .HasColumnType("tinyint");

                    b.Property<byte?>("ShariaSubscriptionWay")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("PractitionerId")
                        .IsUnique();

                    b.ToTable("TbPractitionerSpec");
                });

            modelBuilder.Entity("Domains.Models.TbPerson", b =>
                {
                    b.HasOne("Domains.Models.TbPractitioner", null)
                        .WithOne("TbPerson")
                        .HasForeignKey("Domains.Models.TbPerson", "PractitionerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domains.Models.TbCountry", "TbCountry")
                        .WithMany("TbPeople")
                        .HasForeignKey("TbCountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TbCountry");
                });

            modelBuilder.Entity("Domains.Models.TbPractitionerSpec", b =>
                {
                    b.HasOne("Domains.Models.TbPractitioner", null)
                        .WithOne("TbPractitionerSpec")
                        .HasForeignKey("Domains.Models.TbPractitionerSpec", "PractitionerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domains.Models.TbCountry", b =>
                {
                    b.Navigation("TbPeople");
                });

            modelBuilder.Entity("Domains.Models.TbPractitioner", b =>
                {
                    b.Navigation("TbPerson")
                        .IsRequired();

                    b.Navigation("TbPractitionerSpec")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}