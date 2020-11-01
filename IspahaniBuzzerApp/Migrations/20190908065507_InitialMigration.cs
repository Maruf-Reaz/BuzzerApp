using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IspahaniBuzzerApp.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    EmployeeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BuzzerMarks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BuzzerNumber = table.Column<int>(nullable: false),
                    CorrectAnswer = table.Column<int>(nullable: true),
                    WrongAnswer = table.Column<int>(nullable: true),
                    NotAnswered = table.Column<int>(nullable: true),
                    TotalMark = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuzzerMarks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BuzzerTimes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BuzzerNumber = table.Column<int>(nullable: false),
                    EnableTime = table.Column<DateTime>(nullable: true),
                    PressTime = table.Column<DateTime>(nullable: true),
                    IsFirst = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuzzerTimes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Option1 = table.Column<string>(nullable: true),
                    Option2 = table.Column<string>(nullable: true),
                    Option3 = table.Column<string>(nullable: true),
                    Option4 = table.Column<string>(nullable: true),
                    IsOption1Correct = table.Column<bool>(nullable: false),
                    IsOption2Correct = table.Column<bool>(nullable: false),
                    IsOption3Correct = table.Column<bool>(nullable: false),
                    IsOption4Correct = table.Column<bool>(nullable: false),
                    ExamId = table.Column<int>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedOn", "Description", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3f07295e-a6f1-43d4-9c05-802417be74f0", "2f746ca3-e45b-4b5a-8ff7-3c21d53b38a5", new DateTime(2019, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Adminstrator Role", "Admin", "ADMIN" },
                    { "42ca669f-5f0b-47ef-9f82-77a1e7ebbbf1", "f2a4cf93-6ee5-4f4b-9e4c-a76daee27214", new DateTime(2019, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Student Role", "Student", "STUDENT" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "8e09035f-c640-4ac0-8d5c-4a63d3eddfab", 0, "e82dfec2-1080-4e52-93dd-a7aebe4d8522", null, false, null, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEK8bD4QQC1iYCUrcSS1X6OeuFriOTyhQCm/Ei1VBtK4gH/QPssb1rJIHtf58Q2a/fQ==", null, false, "AR3FNIFN2MZIT75JW6AY36E4IDWL5DLE", false, "Admin" },
                    { "3bb02f23-930a-40dd-8148-52e2645fdd71", 0, "6a422c6f-967d-4f34-9100-70123db20919", null, false, null, false, null, null, "STUDENT1", "AQAAAAEAACcQAAAAEHz4wTVVXCCi5h3svRAIeeHMGQ66O4ilRPckLqWNzElq8OYHBE0Xv/a1rXdilVBNIw==", null, false, "Y7FJEYQ5IYJFCSY6FPPLCDLDAFKYPGO5", false, "Student1" },
                    { "10357147-691e-4af6-bc2d-dca7b264050b", 0, "74d7b2a0-e7ba-4980-a1c8-8eebe3e66408", null, false, null, false, null, null, "STUDENT2", "AQAAAAEAACcQAAAAEGTmuY8nLr2D7AUGoUyhmi7UHPW+ZVy5JiKDzfwl4nGEMgQWmz1bx0QlprKiiKAlkA==", null, false, "YGSB2UPGZ2EPN55GKFNUI2T6R2S7OFF4", false, "Student2" },
                    { "3a3b7b2b-26e8-4c03-ba7d-d31f507359d0", 0, "a7f617d5-ebe4-4e72-afe8-cc084fcfc5cc", null, false, null, false, null, null, "STUDENT3", "AQAAAAEAACcQAAAAEHvQ0XKMw8X+w5pcIeW2odvLdexl3WToXlxyP3alg8yvy91j2i1T1v/o8nTvIchJbg==", null, false, "ONHSZUZYWUETTWGET4NSRY2VJ243EJ3K", false, "Student3" },
                    { "f78a5700-2be1-4e04-a8eb-569ce9985cdc", 0, "ecc47a93-1dc1-4bbf-8d70-38f1aee1edc6", null, false, null, false, null, null, "STUDENT4", "AQAAAAEAACcQAAAAEEklqz7aCWbQ67beC8aEwpWO0DuLbWymi/TN4D4E1dZZ02iYJayX/QN/OMxWI4Z7pw==", null, false, "YYXN6NLLB7FGHYVT7S773IROQAGMKPKJ", false, "Student4" },
                    { "101fc180-23ad-47ca-9c7f-c456aeb40edc", 0, "73beadae-ca51-4b42-b692-aaaf8cb5915a", null, false, null, false, null, null, "STUDENT5", "AQAAAAEAACcQAAAAEG1hDAk2qSq0FQLfEeB7eBKCV5Mq32WM0if6ZPLjR8NIWGh2GyEU9oyvrt5/DsAOrQ==", null, false, "AUHYUQVZYNV4TDIFIMTQBBGYWFLNURD7", false, "Student5" },
                    { "7aee2ac4-ff3b-4351-83ea-1c11c1e2bb46", 0, "54510157-34ba-4baa-9678-8796fd194216", null, false, null, false, null, null, "STUDENT6", "AQAAAAEAACcQAAAAEC/wn7gWjJONMvkfuSTHjS/EVXgt26BT/APeEW2eSHalZNipyFn7cILnnUcTzEHTZA==", null, false, "C3UOJJDKHP3KDBKRBAKD23OGFNRAVCZ7", false, "Student6" }
                });

            migrationBuilder.InsertData(
                table: "BuzzerMarks",
                columns: new[] { "Id", "BuzzerNumber", "CorrectAnswer", "NotAnswered", "TotalMark", "WrongAnswer" },
                values: new object[,]
                {
                    { 6, 6, 0, 0, 0.0, 0 },
                    { 5, 5, 0, 0, 0.0, 0 },
                    { 4, 4, 0, 0, 0.0, 0 },
                    { 2, 2, 0, 0, 0.0, 0 },
                    { 1, 1, 0, 0, 0.0, 0 },
                    { 3, 3, 0, 0, 0.0, 0 }
                });

            migrationBuilder.InsertData(
                table: "BuzzerTimes",
                columns: new[] { "Id", "BuzzerNumber", "EnableTime", "IsFirst", "PressTime" },
                values: new object[,]
                {
                    { 5, 5, null, false, null },
                    { 1, 1, null, false, null },
                    { 2, 2, null, false, null },
                    { 3, 3, null, false, null },
                    { 4, 4, null, false, null },
                    { 6, 6, null, false, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_ExamId",
                table: "Questions",
                column: "ExamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "BuzzerMarks");

            migrationBuilder.DropTable(
                name: "BuzzerTimes");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Exams");
        }
    }
}
