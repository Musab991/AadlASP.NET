﻿// <auto-generated />
using System;
using BusinessLib.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BusinessLib.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domains.Models.Identity.ApplicationRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Domains.Models.Identity.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Domains.Models.TbCaseType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PractitionerTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PractitionerTypeId");

                    b.ToTable("TbCaseTypes", (string)null);
                });

            modelBuilder.Entity("Domains.Models.TbCountry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("TbCounrties", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 51,
                            Name = "Jordan"
                        },
                        new
                        {
                            Id = 1,
                            Name = "United States"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Canada"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Mexico"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Brazil"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Argentina"
                        },
                        new
                        {
                            Id = 6,
                            Name = "United Kingdom"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Germany"
                        },
                        new
                        {
                            Id = 8,
                            Name = "France"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Italy"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Spain"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Russia"
                        },
                        new
                        {
                            Id = 12,
                            Name = "China"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Japan"
                        },
                        new
                        {
                            Id = 14,
                            Name = "South Korea"
                        },
                        new
                        {
                            Id = 15,
                            Name = "India"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Australia"
                        },
                        new
                        {
                            Id = 17,
                            Name = "New Zealand"
                        },
                        new
                        {
                            Id = 18,
                            Name = "South Africa"
                        },
                        new
                        {
                            Id = 19,
                            Name = "Egypt"
                        },
                        new
                        {
                            Id = 20,
                            Name = "Nigeria"
                        },
                        new
                        {
                            Id = 21,
                            Name = "Kenya"
                        },
                        new
                        {
                            Id = 22,
                            Name = "Saudi Arabia"
                        },
                        new
                        {
                            Id = 23,
                            Name = "United Arab Emirates"
                        },
                        new
                        {
                            Id = 24,
                            Name = "Turkey"
                        },
                        new
                        {
                            Id = 25,
                            Name = "Iran"
                        },
                        new
                        {
                            Id = 26,
                            Name = "Israel"
                        },
                        new
                        {
                            Id = 27,
                            Name = "Pakistan"
                        },
                        new
                        {
                            Id = 28,
                            Name = "Bangladesh"
                        },
                        new
                        {
                            Id = 29,
                            Name = "Indonesia"
                        },
                        new
                        {
                            Id = 30,
                            Name = "Vietnam"
                        },
                        new
                        {
                            Id = 31,
                            Name = "Thailand"
                        },
                        new
                        {
                            Id = 32,
                            Name = "Malaysia"
                        },
                        new
                        {
                            Id = 33,
                            Name = "Singapore"
                        },
                        new
                        {
                            Id = 34,
                            Name = "Philippines"
                        },
                        new
                        {
                            Id = 35,
                            Name = "Greece"
                        },
                        new
                        {
                            Id = 36,
                            Name = "Sweden"
                        },
                        new
                        {
                            Id = 37,
                            Name = "Norway"
                        },
                        new
                        {
                            Id = 38,
                            Name = "Denmark"
                        },
                        new
                        {
                            Id = 39,
                            Name = "Finland"
                        },
                        new
                        {
                            Id = 40,
                            Name = "Poland"
                        },
                        new
                        {
                            Id = 41,
                            Name = "Netherlands"
                        },
                        new
                        {
                            Id = 42,
                            Name = "Belgium"
                        },
                        new
                        {
                            Id = 43,
                            Name = "Switzerland"
                        },
                        new
                        {
                            Id = 44,
                            Name = "Austria"
                        },
                        new
                        {
                            Id = 45,
                            Name = "Portugal"
                        },
                        new
                        {
                            Id = 46,
                            Name = "Chile"
                        },
                        new
                        {
                            Id = 47,
                            Name = "Colombia"
                        },
                        new
                        {
                            Id = 48,
                            Name = "Peru"
                        },
                        new
                        {
                            Id = 49,
                            Name = "Venezuela"
                        },
                        new
                        {
                            Id = 50,
                            Name = "Cuba"
                        });
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

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThirdName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UpdateByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("TbPeople", (string)null);
                });

            modelBuilder.Entity("Domains.Models.TbPractitioner", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CreatedByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int?>("PractitionerSpecId")
                        .HasColumnType("int");

                    b.Property<int>("PractitionerTypeId")
                        .HasColumnType("int");

                    b.Property<int?>("UpdatedByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.HasIndex("PractitionerTypeId");

                    b.ToTable("TbPractitioners", (string)null);
                });

            modelBuilder.Entity("Domains.Models.TbPractitionerCase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CaseId")
                        .HasColumnType("int");

                    b.Property<int>("PractitionerId")
                        .HasColumnType("int");

                    b.Property<int>("PractitionerTypeId")
                        .HasColumnType("INT")
                        .HasColumnName("PractitionerTypeId");

                    b.HasKey("Id");

                    b.HasIndex("PractitionerId");

                    b.HasIndex("PractitionerTypeId");

                    b.ToTable("TbPractitionersCases", (string)null);
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

                    b.ToTable("TbPractitionerSpecs");
                });

            modelBuilder.Entity("Domains.Models.TbPractitionerType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PractitionerTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TbPractitionerTypes", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Domains.Models.TbCaseType", b =>
                {
                    b.HasOne("Domains.Models.TbPractitionerType", null)
                        .WithMany()
                        .HasForeignKey("PractitionerTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domains.Models.TbPerson", b =>
                {
                    b.HasOne("Domains.Models.TbCountry", "TbCountry")
                        .WithMany()
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TbCountry");
                });

            modelBuilder.Entity("Domains.Models.TbPractitioner", b =>
                {
                    b.HasOne("Domains.Models.TbPerson", "TbPerson")
                        .WithOne()
                        .HasForeignKey("Domains.Models.TbPractitioner", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domains.Models.TbPractitionerType", null)
                        .WithMany()
                        .HasForeignKey("PractitionerTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TbPerson");
                });

            modelBuilder.Entity("Domains.Models.TbPractitionerCase", b =>
                {
                    b.HasOne("Domains.Models.TbCaseType", "TbCaseType")
                        .WithMany()
                        .HasForeignKey("PractitionerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domains.Models.TbPractitionerType", null)
                        .WithMany()
                        .HasForeignKey("PractitionerTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TbCaseType");
                });

            modelBuilder.Entity("Domains.Models.TbPractitionerSpec", b =>
                {
                    b.HasOne("Domains.Models.TbPractitioner", null)
                        .WithOne("TbPractitionerSpec")
                        .HasForeignKey("Domains.Models.TbPractitionerSpec", "PractitionerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Domains.Models.Identity.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Domains.Models.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Domains.Models.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Domains.Models.Identity.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domains.Models.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Domains.Models.Identity.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domains.Models.TbPractitioner", b =>
                {
                    b.Navigation("TbPractitionerSpec")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
