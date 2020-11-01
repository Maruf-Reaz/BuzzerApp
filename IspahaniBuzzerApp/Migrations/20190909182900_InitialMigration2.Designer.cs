﻿// <auto-generated />
using System;
using Dynamo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IspahaniBuzzerApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190909182900_InitialMigration2")]
    partial class InitialMigration2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dynamo.Model.Common.Authentication.ApplicationRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<DateTime?>("CreatedOn");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "3f07295e-a6f1-43d4-9c05-802417be74f0",
                            ConcurrencyStamp = "2f746ca3-e45b-4b5a-8ff7-3c21d53b38a5",
                            CreatedOn = new DateTime(2019, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Adminstrator Role",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "42ca669f-5f0b-47ef-9f82-77a1e7ebbbf1",
                            ConcurrencyStamp = "f2a4cf93-6ee5-4f4b-9e4c-a76daee27214",
                            CreatedOn = new DateTime(2019, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Student Role",
                            Name = "Student",
                            NormalizedName = "STUDENT"
                        });
                });

            modelBuilder.Entity("Dynamo.Model.Common.Authentication.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<int?>("EmployeeId");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = "8e09035f-c640-4ac0-8d5c-4a63d3eddfab",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "e82dfec2-1080-4e52-93dd-a7aebe4d8522",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEK8bD4QQC1iYCUrcSS1X6OeuFriOTyhQCm/Ei1VBtK4gH/QPssb1rJIHtf58Q2a/fQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "AR3FNIFN2MZIT75JW6AY36E4IDWL5DLE",
                            TwoFactorEnabled = false,
                            UserName = "Admin"
                        },
                        new
                        {
                            Id = "3bb02f23-930a-40dd-8148-52e2645fdd71",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "6a422c6f-967d-4f34-9100-70123db20919",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "STUDENT1",
                            PasswordHash = "AQAAAAEAACcQAAAAEHz4wTVVXCCi5h3svRAIeeHMGQ66O4ilRPckLqWNzElq8OYHBE0Xv/a1rXdilVBNIw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "Y7FJEYQ5IYJFCSY6FPPLCDLDAFKYPGO5",
                            TwoFactorEnabled = false,
                            UserName = "Student1"
                        },
                        new
                        {
                            Id = "10357147-691e-4af6-bc2d-dca7b264050b",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "74d7b2a0-e7ba-4980-a1c8-8eebe3e66408",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "STUDENT2",
                            PasswordHash = "AQAAAAEAACcQAAAAEGTmuY8nLr2D7AUGoUyhmi7UHPW+ZVy5JiKDzfwl4nGEMgQWmz1bx0QlprKiiKAlkA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "YGSB2UPGZ2EPN55GKFNUI2T6R2S7OFF4",
                            TwoFactorEnabled = false,
                            UserName = "Student2"
                        },
                        new
                        {
                            Id = "3a3b7b2b-26e8-4c03-ba7d-d31f507359d0",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a7f617d5-ebe4-4e72-afe8-cc084fcfc5cc",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "STUDENT3",
                            PasswordHash = "AQAAAAEAACcQAAAAEHvQ0XKMw8X+w5pcIeW2odvLdexl3WToXlxyP3alg8yvy91j2i1T1v/o8nTvIchJbg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "ONHSZUZYWUETTWGET4NSRY2VJ243EJ3K",
                            TwoFactorEnabled = false,
                            UserName = "Student3"
                        },
                        new
                        {
                            Id = "f78a5700-2be1-4e04-a8eb-569ce9985cdc",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "ecc47a93-1dc1-4bbf-8d70-38f1aee1edc6",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "STUDENT4",
                            PasswordHash = "AQAAAAEAACcQAAAAEEklqz7aCWbQ67beC8aEwpWO0DuLbWymi/TN4D4E1dZZ02iYJayX/QN/OMxWI4Z7pw==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "YYXN6NLLB7FGHYVT7S773IROQAGMKPKJ",
                            TwoFactorEnabled = false,
                            UserName = "Student4"
                        },
                        new
                        {
                            Id = "101fc180-23ad-47ca-9c7f-c456aeb40edc",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "73beadae-ca51-4b42-b692-aaaf8cb5915a",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "STUDENT5",
                            PasswordHash = "AQAAAAEAACcQAAAAEG1hDAk2qSq0FQLfEeB7eBKCV5Mq32WM0if6ZPLjR8NIWGh2GyEU9oyvrt5/DsAOrQ==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "AUHYUQVZYNV4TDIFIMTQBBGYWFLNURD7",
                            TwoFactorEnabled = false,
                            UserName = "Student5"
                        },
                        new
                        {
                            Id = "7aee2ac4-ff3b-4351-83ea-1c11c1e2bb46",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "54510157-34ba-4baa-9678-8796fd194216",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "STUDENT6",
                            PasswordHash = "AQAAAAEAACcQAAAAEC/wn7gWjJONMvkfuSTHjS/EVXgt26BT/APeEW2eSHalZNipyFn7cILnnUcTzEHTZA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "C3UOJJDKHP3KDBKRBAKD23OGFNRAVCZ7",
                            TwoFactorEnabled = false,
                            UserName = "Student6"
                        });
                });

            modelBuilder.Entity("Dynamo.Model.Exam.BuzzerMark", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BuzzerNumber");

                    b.Property<int?>("CorrectAnswer");

                    b.Property<int?>("NotAnswered");

                    b.Property<double?>("TotalMark");

                    b.Property<int?>("WrongAnswer");

                    b.HasKey("Id");

                    b.ToTable("BuzzerMarks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BuzzerNumber = 1,
                            CorrectAnswer = 0,
                            NotAnswered = 0,
                            TotalMark = 0.0,
                            WrongAnswer = 0
                        },
                        new
                        {
                            Id = 2,
                            BuzzerNumber = 2,
                            CorrectAnswer = 0,
                            NotAnswered = 0,
                            TotalMark = 0.0,
                            WrongAnswer = 0
                        },
                        new
                        {
                            Id = 3,
                            BuzzerNumber = 3,
                            CorrectAnswer = 0,
                            NotAnswered = 0,
                            TotalMark = 0.0,
                            WrongAnswer = 0
                        },
                        new
                        {
                            Id = 4,
                            BuzzerNumber = 4,
                            CorrectAnswer = 0,
                            NotAnswered = 0,
                            TotalMark = 0.0,
                            WrongAnswer = 0
                        },
                        new
                        {
                            Id = 5,
                            BuzzerNumber = 5,
                            CorrectAnswer = 0,
                            NotAnswered = 0,
                            TotalMark = 0.0,
                            WrongAnswer = 0
                        },
                        new
                        {
                            Id = 6,
                            BuzzerNumber = 6,
                            CorrectAnswer = 0,
                            NotAnswered = 0,
                            TotalMark = 0.0,
                            WrongAnswer = 0
                        });
                });

            modelBuilder.Entity("Dynamo.Model.Exam.BuzzerTime", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BuzzerNumber");

                    b.Property<DateTime?>("EnableTime");

                    b.Property<bool>("IsFirst");

                    b.Property<DateTime?>("PressTime");

                    b.HasKey("Id");

                    b.ToTable("BuzzerTimes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BuzzerNumber = 1,
                            IsFirst = false
                        },
                        new
                        {
                            Id = 2,
                            BuzzerNumber = 2,
                            IsFirst = false
                        },
                        new
                        {
                            Id = 3,
                            BuzzerNumber = 3,
                            IsFirst = false
                        },
                        new
                        {
                            Id = 4,
                            BuzzerNumber = 4,
                            IsFirst = false
                        },
                        new
                        {
                            Id = 5,
                            BuzzerNumber = 5,
                            IsFirst = false
                        },
                        new
                        {
                            Id = 6,
                            BuzzerNumber = 6,
                            IsFirst = false
                        });
                });

            modelBuilder.Entity("Dynamo.Model.Exam.Exam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("TypeId");

                    b.HasKey("Id");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("Dynamo.Model.Exam.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<int>("ExamId");

                    b.Property<bool>("IsActive");

                    b.Property<bool>("IsOption1Correct");

                    b.Property<bool>("IsOption2Correct");

                    b.Property<bool>("IsOption3Correct");

                    b.Property<bool>("IsOption4Correct");

                    b.Property<string>("Option1");

                    b.Property<string>("Option2");

                    b.Property<string>("Option3");

                    b.Property<string>("Option4");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Dynamo.Model.Exam.Question", b =>
                {
                    b.HasOne("Dynamo.Model.Exam.Exam", "Exam")
                        .WithMany("Questions")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Dynamo.Model.Common.Authentication.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Dynamo.Model.Common.Authentication.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Dynamo.Model.Common.Authentication.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Dynamo.Model.Common.Authentication.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Dynamo.Model.Common.Authentication.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Dynamo.Model.Common.Authentication.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}