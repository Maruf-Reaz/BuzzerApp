using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IspahaniBuzzerApp.Migrations
{
    public partial class MCQUserAndRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "CreatedOn", "Description", "Name", "NormalizedName" },
                values: new object[] { "372ca669g-5f0d-47et-9f82-99a1e7ebbbf2", "h2a4cf93-6ee5-4f4h-9e4d-a76daee37215", new DateTime(2019, 9, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "MCQStudent Role", "MCQStudent", "MCQSTUDENT" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "EmployeeId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "8aee2ac4-ff3b-6796-83em-13c11c1e2bb62", 0, "54510157-34ba-5bab-9679-8796fd194232", null, false, null, false, null, null, "MCQSTUDENT16", "AQAAAAEAACcQAAAAEMwir2Ry6QPjmxbX2uvOvURQl64u1tO9Iq79RopAbKEvNKi7CjX8F6BIB0wRmJUMsQ==", null, false, "L3UOJJDKHP3KDBKRBAKD29OGFNRAVCZ16", false, "MCQStudent16" },
                    { "8aee2ac4-ff3b-6795-83em-13c11c1e2bb61", 0, "54510157-34ba-5bab-9679-8796fd194231", null, false, null, false, null, null, "MCQSTUDENT15", "AQAAAAEAACcQAAAAEMwir2Ry6QPjmxbX2uvOvURQl64u1tO9Iq79RopAbKEvNKi7CjX8F6BIB0wRmJUMsQ==", null, false, "L3UOJJDKHP3KDBKRBAKD29OGFNRAVCZ15", false, "MCQStudent15" },
                    { "8aee2ac4-ff3b-6794-83em-13c11c1e2bb60", 0, "54510157-34ba-5bab-9679-8796fd194230", null, false, null, false, null, null, "MCQSTUDENT14", "AQAAAAEAACcQAAAAEMwir2Ry6QPjmxbX2uvOvURQl64u1tO9Iq79RopAbKEvNKi7CjX8F6BIB0wRmJUMsQ==", null, false, "L3UOJJDKHP3KDBKRBAKD29OGFNRAVCZ14", false, "MCQStudent14" },
                    { "8aee2ac4-ff3b-6793-83em-13c11c1e2bb59", 0, "54510157-34ba-5bab-9679-8796fd194229", null, false, null, false, null, null, "MCQSTUDENT13", "AQAAAAEAACcQAAAAEMwir2Ry6QPjmxbX2uvOvURQl64u1tO9Iq79RopAbKEvNKi7CjX8F6BIB0wRmJUMsQ==", null, false, "L3UOJJDKHP3KDBKRBAKD29OGFNRAVCZ13", false, "MCQStudent13" },
                    { "8aee2ac4-ff3b-6792-83em-13c11c1e2bb58", 0, "54510157-34ba-5bab-9679-8796fd194228", null, false, null, false, null, null, "MCQSTUDENT12", "AQAAAAEAACcQAAAAEMwir2Ry6QPjmxbX2uvOvURQl64u1tO9Iq79RopAbKEvNKi7CjX8F6BIB0wRmJUMsQ==", null, false, "L3UOJJDKHP3KDBKRBAKD29OGFNRAVCZ12", false, "MCQStudent12" },
                    { "8aee2ac4-ff3b-6791-83el-12c11c1e2bb57", 0, "54510157-34ba-5bac-9679-8796fd194227", null, false, null, false, null, null, "MCQSTUDENT11", "AQAAAAEAACcQAAAAEMwir2Ry6QPjmxbX2uvOvURQl64u1tO9Iq79RopAbKEvNKi7CjX8F6BIB0wRmJUMsQ==", null, false, "K3UOJJDKHP3KDBKRBAKD29OGFNRAVCZ11", false, "MCQStudent11" },
                    { "8aee2ac4-ff3b-6790-83ek-11c11c1e2bb56", 0, "54510157-34ba-5bad-9679-8796fd194226", null, false, null, false, null, null, "MCQSTUDENT10", "AQAAAAEAACcQAAAAEMwir2Ry6QPjmxbX2uvOvURQl64u1tO9Iq79RopAbKEvNKi7CjX8F6BIB0wRmJUMsQ==", null, false, "J3UOJJDKHP3KDBKRBAKD29OGFNRAVCZ10", false, "MCQStudent10" },
                    { "8aee2ac4-ff3b-6797-83em-13c11c1e2bb63", 0, "54510157-34ba-5bab-9679-8796fd194233", null, false, null, false, null, null, "MCQSTUDENT17", "AQAAAAEAACcQAAAAEMwir2Ry6QPjmxbX2uvOvURQl64u1tO9Iq79RopAbKEvNKi7CjX8F6BIB0wRmJUMsQ==", null, false, "L3UOJJDKHP3KDBKRBAKD29OGFNRAVCZ17", false, "MCQStudent17" },
                    { "8aee2ac4-ff3b-6789-83ej-10c11c1e2bb55", 0, "54510157-34ba-5bae-9679-8796fd194225", null, false, null, false, null, null, "MCQSTUDENT9", "AQAAAAEAACcQAAAAEMwir2Ry6QPjmxbX2uvOvURQl64u1tO9Iq79RopAbKEvNKi7CjX8F6BIB0wRmJUMsQ==", null, false, "I3UOJJDKHP3KDBKRBAKD29OGFNRAVCZ9", false, "MCQStudent9" },
                    { "8aee2ac4-ff3b-6787-83eh-8c11c1e2bb53", 0, "54510157-34ba-5bag-9679-8796fd194223", null, false, null, false, null, null, "MCQSTUDENT7", "AQAAAAEAACcQAAAAEMwir2Ry6QPjmxbX2uvOvURQl64u1tO9Iq79RopAbKEvNKi7CjX8F6BIB0wRmJUMsQ==", null, false, "G3UOJJDKHP3KDBKRBAKD29OGFNRAVCZ7", false, "MCQStudent7" },
                    { "8aee2ac4-ff3b-6786-83eg-7c11c1e2bb52", 0, "54510157-34ba-5bah-9679-8796fd194222", null, false, null, false, null, null, "MCQSTUDENT6", "AQAAAAEAACcQAAAAEMwir2Ry6QPjmxbX2uvOvURQl64u1tO9Iq79RopAbKEvNKi7CjX8F6BIB0wRmJUMsQ==", null, false, "F3UOJJDKHP3KDBKRBAKD29OGFNRAVCZ6", false, "MCQStudent6" },
                    { "8aee2ac4-ff3b-6785-83ef-6c11c1e2bb51", 0, "54510157-34ba-5bai-9679-8796fd194221", null, false, null, false, null, null, "MCQSTUDENT5", "AQAAAAEAACcQAAAAEMwir2Ry6QPjmxbX2uvOvURQl64u1tO9Iq79RopAbKEvNKi7CjX8F6BIB0wRmJUMsQ==", null, false, "E3UOJJDKHP3KDBKRBAKD28OGFNRAVCZ5", false, "MCQStudent5" },
                    { "8aee2ac4-ff3b-6784-83ee-5c11c1e2bb50", 0, "54510157-34ba-5baj-9679-8796fd194220", null, false, null, false, null, null, "MCQSTUDENT4", "AQAAAAEAACcQAAAAEMwir2Ry6QPjmxbX2uvOvURQl64u1tO9Iq79RopAbKEvNKi7CjX8F6BIB0wRmJUMsQ==", null, false, "D3UOJJDKHP3KDBKRBAKD27OGFNRAVCZ4", false, "MCQStudent4" },
                    { "8aee2ac4-ff3b-6783-83ed-4c11c1e2bb49", 0, "54510157-34ba-5bak-9679-8796fd194219", null, false, null, false, null, null, "MCQSTUDENT3", "AQAAAAEAACcQAAAAEMwir2Ry6QPjmxbX2uvOvURQl64u1tO9Iq79RopAbKEvNKi7CjX8F6BIB0wRmJUMsQ==", null, false, "C3UOJJDKHP3KDBKRBAKD26OGFNRAVCZ3", false, "MCQStudent3" },
                    { "8aee2ac4-ff3b-6782-83ec-3c11c1e2bb48", 0, "54510157-34ba-5bal-9679-8796fd194218", null, false, null, false, null, null, "MCQSTUDENT2", "AQAAAAEAACcQAAAAEMwir2Ry6QPjmxbX2uvOvURQl64u1tO9Iq79RopAbKEvNKi7CjX8F6BIB0wRmJUMsQ==", null, false, "B3UOJJDKHP3KDBKRBAKD25OGFNRAVCZ2", false, "MCQStudent2" },
                    { "8aee2ac4-ff3b-6781-83eb-2c11c1e2bb47", 0, "54510157-34ba-5bam-9679-8796fd194217", null, false, null, false, null, null, "MCQSTUDENT1", "AQAAAAEAACcQAAAAEMwir2Ry6QPjmxbX2uvOvURQl64u1tO9Iq79RopAbKEvNKi7CjX8F6BIB0wRmJUMsQ==", null, false, "A3UOJJDKHP3KDBKRBAKD24OGFNRAVCZ1", false, "MCQStudent1" },
                    { "8aee2ac4-ff3b-6788-83ei-9c11c1e2bb54", 0, "54510157-34ba-5baf-9679-8796fd194224", null, false, null, false, null, null, "MCQSTUDENT8", "AQAAAAEAACcQAAAAEMwir2Ry6QPjmxbX2uvOvURQl64u1tO9Iq79RopAbKEvNKi7CjX8F6BIB0wRmJUMsQ==", null, false, "H3UOJJDKHP3KDBKRBAKD29OGFNRAVCZ8", false, "MCQStudent8" },
                    { "8aee2ac4-ff3b-6798-83em-13c11c1e2bb64", 0, "54510157-34ba-5bab-9679-8796fd194234", null, false, null, false, null, null, "MCQSTUDENT18", "AQAAAAEAACcQAAAAEMwir2Ry6QPjmxbX2uvOvURQl64u1tO9Iq79RopAbKEvNKi7CjX8F6BIB0wRmJUMsQ==", null, false, "L3UOJJDKHP3KDBKRBAKD29OGFNRAVCZ18", false, "MCQStudent18" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "372ca669g-5f0d-47et-9f82-99a1e7ebbbf2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8aee2ac4-ff3b-6781-83eb-2c11c1e2bb47");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8aee2ac4-ff3b-6782-83ec-3c11c1e2bb48");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8aee2ac4-ff3b-6783-83ed-4c11c1e2bb49");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8aee2ac4-ff3b-6784-83ee-5c11c1e2bb50");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8aee2ac4-ff3b-6785-83ef-6c11c1e2bb51");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8aee2ac4-ff3b-6786-83eg-7c11c1e2bb52");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8aee2ac4-ff3b-6787-83eh-8c11c1e2bb53");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8aee2ac4-ff3b-6788-83ei-9c11c1e2bb54");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8aee2ac4-ff3b-6789-83ej-10c11c1e2bb55");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8aee2ac4-ff3b-6790-83ek-11c11c1e2bb56");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8aee2ac4-ff3b-6791-83el-12c11c1e2bb57");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8aee2ac4-ff3b-6792-83em-13c11c1e2bb58");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8aee2ac4-ff3b-6793-83em-13c11c1e2bb59");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8aee2ac4-ff3b-6794-83em-13c11c1e2bb60");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8aee2ac4-ff3b-6795-83em-13c11c1e2bb61");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8aee2ac4-ff3b-6796-83em-13c11c1e2bb62");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8aee2ac4-ff3b-6797-83em-13c11c1e2bb63");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8aee2ac4-ff3b-6798-83em-13c11c1e2bb64");
        }
    }
}
