// using IspahaniBuzzer.Model.Common.Authentication;
//using Dynamo.Model.Common.Authentication;
using Dynamo.Model.Common.Authentication;
using Dynamo.Model.Exam;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dynamo.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        //Join Table for many to many relationship between Job and Option Model
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Planning And Estimation
            modelBuilder.Entity<BuzzerTime>().HasData(
               new BuzzerTime() { Id = 1, BuzzerNumber = 1, EnableTime = null, PressTime = null },
               new BuzzerTime() { Id = 2, BuzzerNumber = 2, EnableTime = null, PressTime = null },
               new BuzzerTime() { Id = 3, BuzzerNumber = 3, EnableTime = null, PressTime = null },
               new BuzzerTime() { Id = 4, BuzzerNumber = 4, EnableTime = null, PressTime = null },
               new BuzzerTime() { Id = 5, BuzzerNumber = 5, EnableTime = null, PressTime = null },
               new BuzzerTime() { Id = 6, BuzzerNumber = 6, EnableTime = null, PressTime = null }
               );

            modelBuilder.Entity<BuzzerMark>().HasData(
              new BuzzerMark() { Id = 1, BuzzerNumber = 1, CorrectAnswer = 0, WrongAnswer = 0, NotAnswered = 0, TotalMark = 0 },
              new BuzzerMark() { Id = 2, BuzzerNumber = 2, CorrectAnswer = 0, WrongAnswer = 0, NotAnswered = 0, TotalMark = 0 },
              new BuzzerMark() { Id = 3, BuzzerNumber = 3, CorrectAnswer = 0, WrongAnswer = 0, NotAnswered = 0, TotalMark = 0 },
              new BuzzerMark() { Id = 4, BuzzerNumber = 4, CorrectAnswer = 0, WrongAnswer = 0, NotAnswered = 0, TotalMark = 0 },
              new BuzzerMark() { Id = 5, BuzzerNumber = 5, CorrectAnswer = 0, WrongAnswer = 0, NotAnswered = 0, TotalMark = 0 },
              new BuzzerMark() { Id = 6, BuzzerNumber = 6, CorrectAnswer = 0, WrongAnswer = 0, NotAnswered = 0, TotalMark = 0 }
              );

            modelBuilder.Entity<ApplicationRole>().HasData(
              new ApplicationRole() { Id = "3f07295e-a6f1-43d4-9c05-802417be74f0", Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = "2f746ca3-e45b-4b5a-8ff7-3c21d53b38a5", CreatedOn = Convert.ToDateTime("2019-09-08 00:00:00.0000000"), Description = "Adminstrator Role" },
              new ApplicationRole() { Id = "42ca669f-5f0b-47ef-9f82-77a1e7ebbbf1", Name = "Student", NormalizedName = "STUDENT", ConcurrencyStamp = "f2a4cf93-6ee5-4f4b-9e4c-a76daee27214", CreatedOn = Convert.ToDateTime("2019-09-08 00:00:00.0000000"), Description = "Student Role" },
              new ApplicationRole() { Id = "372ca669g-5f0d-47et-9f82-99a1e7ebbbf2", Name = "MCQStudent", NormalizedName = "MCQSTUDENT", ConcurrencyStamp = "h2a4cf93-6ee5-4f4h-9e4d-a76daee37215", CreatedOn = Convert.ToDateTime("2019-09-08 00:00:00.0000000"), Description = "MCQStudent Role" }
             );

            modelBuilder.Entity<ApplicationUser>().HasData(
              new ApplicationUser() { Id = "8e09035f-c640-4ac0-8d5c-4a63d3eddfab", UserName = "Admin", NormalizedUserName = "ADMIN", PasswordHash = "AQAAAAEAACcQAAAAEK8bD4QQC1iYCUrcSS1X6OeuFriOTyhQCm/Ei1VBtK4gH/QPssb1rJIHtf58Q2a/fQ==", SecurityStamp = "AR3FNIFN2MZIT75JW6AY36E4IDWL5DLE", ConcurrencyStamp = "e82dfec2-1080-4e52-93dd-a7aebe4d8522" },
              new ApplicationUser() { Id = "3bb02f23-930a-40dd-8148-52e2645fdd71", UserName = "Student1", NormalizedUserName = "STUDENT1", PasswordHash = "AQAAAAEAACcQAAAAEHz4wTVVXCCi5h3svRAIeeHMGQ66O4ilRPckLqWNzElq8OYHBE0Xv/a1rXdilVBNIw==", SecurityStamp = "Y7FJEYQ5IYJFCSY6FPPLCDLDAFKYPGO5", ConcurrencyStamp = "6a422c6f-967d-4f34-9100-70123db20919" },
              new ApplicationUser() { Id = "10357147-691e-4af6-bc2d-dca7b264050b", UserName = "Student2", NormalizedUserName = "STUDENT2", PasswordHash = "AQAAAAEAACcQAAAAEGTmuY8nLr2D7AUGoUyhmi7UHPW+ZVy5JiKDzfwl4nGEMgQWmz1bx0QlprKiiKAlkA==", SecurityStamp = "YGSB2UPGZ2EPN55GKFNUI2T6R2S7OFF4", ConcurrencyStamp = "74d7b2a0-e7ba-4980-a1c8-8eebe3e66408" },
              new ApplicationUser() { Id = "3a3b7b2b-26e8-4c03-ba7d-d31f507359d0", UserName = "Student3", NormalizedUserName = "STUDENT3", PasswordHash = "AQAAAAEAACcQAAAAEHvQ0XKMw8X+w5pcIeW2odvLdexl3WToXlxyP3alg8yvy91j2i1T1v/o8nTvIchJbg==", SecurityStamp = "ONHSZUZYWUETTWGET4NSRY2VJ243EJ3K", ConcurrencyStamp = "a7f617d5-ebe4-4e72-afe8-cc084fcfc5cc" },
              new ApplicationUser() { Id = "f78a5700-2be1-4e04-a8eb-569ce9985cdc", UserName = "Student4", NormalizedUserName = "STUDENT4", PasswordHash = "AQAAAAEAACcQAAAAEEklqz7aCWbQ67beC8aEwpWO0DuLbWymi/TN4D4E1dZZ02iYJayX/QN/OMxWI4Z7pw==", SecurityStamp = "YYXN6NLLB7FGHYVT7S773IROQAGMKPKJ", ConcurrencyStamp = "ecc47a93-1dc1-4bbf-8d70-38f1aee1edc6" },
              new ApplicationUser() { Id = "101fc180-23ad-47ca-9c7f-c456aeb40edc", UserName = "Student5", NormalizedUserName = "STUDENT5", PasswordHash = "AQAAAAEAACcQAAAAEG1hDAk2qSq0FQLfEeB7eBKCV5Mq32WM0if6ZPLjR8NIWGh2GyEU9oyvrt5/DsAOrQ==", SecurityStamp = "AUHYUQVZYNV4TDIFIMTQBBGYWFLNURD7", ConcurrencyStamp = "73beadae-ca51-4b42-b692-aaaf8cb5915a" },
              new ApplicationUser() { Id = "7aee2ac4-ff3b-4351-83ea-1c11c1e2bb46", UserName = "Student6", NormalizedUserName = "STUDENT6", PasswordHash = "AQAAAAEAACcQAAAAEC/wn7gWjJONMvkfuSTHjS/EVXgt26BT/APeEW2eSHalZNipyFn7cILnnUcTzEHTZA==", SecurityStamp = "C3UOJJDKHP3KDBKRBAKD23OGFNRAVCZ7", ConcurrencyStamp = "54510157-34ba-4baa-9678-8796fd194216" },
              new ApplicationUser() { Id = "8aee2ac4-ff3b-6781-83eb-2c11c1e2bb47", UserName = "MCQStudent1", NormalizedUserName = "MCQSTUDENT1", PasswordHash = "AQAAAAEAACcQAAAAEMwir2Ry6QPjmxbX2uvOvURQl64u1tO9Iq79RopAbKEvNKi7CjX8F6BIB0wRmJUMsQ==", SecurityStamp = "A3UOJJDKHP3KDBKRBAKD24OGFNRAVCZ1", ConcurrencyStamp = "54510157-34ba-5bam-9679-8796fd194217" },
              new ApplicationUser() { Id = "8aee2ac4-ff3b-6782-83ec-3c11c1e2bb48", UserName = "MCQStudent2", NormalizedUserName = "MCQSTUDENT2", PasswordHash = "AQAAAAEAACcQAAAAEMwir2Ry6QPjmxbX2uvOvURQl64u1tO9Iq79RopAbKEvNKi7CjX8F6BIB0wRmJUMsQ==", SecurityStamp = "B3UOJJDKHP3KDBKRBAKD25OGFNRAVCZ2", ConcurrencyStamp = "54510157-34ba-5bal-9679-8796fd194218" },
              new ApplicationUser() { Id = "8aee2ac4-ff3b-6783-83ed-4c11c1e2bb49", UserName = "MCQStudent3", NormalizedUserName = "MCQSTUDENT3", PasswordHash = "AQAAAAEAACcQAAAAEMwir2Ry6QPjmxbX2uvOvURQl64u1tO9Iq79RopAbKEvNKi7CjX8F6BIB0wRmJUMsQ==", SecurityStamp = "C3UOJJDKHP3KDBKRBAKD26OGFNRAVCZ3", ConcurrencyStamp = "54510157-34ba-5bak-9679-8796fd194219" },
              new ApplicationUser() { Id = "8aee2ac4-ff3b-6784-83ee-5c11c1e2bb50", UserName = "MCQStudent4", NormalizedUserName = "MCQSTUDENT4", PasswordHash = "AQAAAAEAACcQAAAAEMwir2Ry6QPjmxbX2uvOvURQl64u1tO9Iq79RopAbKEvNKi7CjX8F6BIB0wRmJUMsQ==", SecurityStamp = "D3UOJJDKHP3KDBKRBAKD27OGFNRAVCZ4", ConcurrencyStamp = "54510157-34ba-5baj-9679-8796fd194220" },
              new ApplicationUser() { Id = "8aee2ac4-ff3b-6785-83ef-6c11c1e2bb51", UserName = "MCQStudent5", NormalizedUserName = "MCQSTUDENT5", PasswordHash = "AQAAAAEAACcQAAAAEMwir2Ry6QPjmxbX2uvOvURQl64u1tO9Iq79RopAbKEvNKi7CjX8F6BIB0wRmJUMsQ==", SecurityStamp = "E3UOJJDKHP3KDBKRBAKD28OGFNRAVCZ5", ConcurrencyStamp = "54510157-34ba-5bai-9679-8796fd194221" },
              new ApplicationUser() { Id = "8aee2ac4-ff3b-6786-83eg-7c11c1e2bb52", UserName = "MCQStudent6", NormalizedUserName = "MCQSTUDENT6", PasswordHash = "AQAAAAEAACcQAAAAEMwir2Ry6QPjmxbX2uvOvURQl64u1tO9Iq79RopAbKEvNKi7CjX8F6BIB0wRmJUMsQ==", SecurityStamp = "F3UOJJDKHP3KDBKRBAKD29OGFNRAVCZ6", ConcurrencyStamp = "54510157-34ba-5bah-9679-8796fd194222" },
              new ApplicationUser() { Id = "8aee2ac4-ff3b-6787-83eh-8c11c1e2bb53", UserName = "MCQStudent7", NormalizedUserName = "MCQSTUDENT7", PasswordHash = "AQAAAAEAACcQAAAAEMwir2Ry6QPjmxbX2uvOvURQl64u1tO9Iq79RopAbKEvNKi7CjX8F6BIB0wRmJUMsQ==", SecurityStamp = "G3UOJJDKHP3KDBKRBAKD29OGFNRAVCZ7", ConcurrencyStamp = "54510157-34ba-5bag-9679-8796fd194223" },
              new ApplicationUser() { Id = "8aee2ac4-ff3b-6788-83ei-9c11c1e2bb54", UserName = "MCQStudent8", NormalizedUserName = "MCQSTUDENT8", PasswordHash = "AQAAAAEAACcQAAAAEMwir2Ry6QPjmxbX2uvOvURQl64u1tO9Iq79RopAbKEvNKi7CjX8F6BIB0wRmJUMsQ==", SecurityStamp = "H3UOJJDKHP3KDBKRBAKD29OGFNRAVCZ8", ConcurrencyStamp = "54510157-34ba-5baf-9679-8796fd194224" },
              new ApplicationUser() { Id = "8aee2ac4-ff3b-6789-83ej-10c11c1e2bb55", UserName = "MCQStudent9", NormalizedUserName = "MCQSTUDENT9", PasswordHash = "AQAAAAEAACcQAAAAEMwir2Ry6QPjmxbX2uvOvURQl64u1tO9Iq79RopAbKEvNKi7CjX8F6BIB0wRmJUMsQ==", SecurityStamp = "I3UOJJDKHP3KDBKRBAKD29OGFNRAVCZ9", ConcurrencyStamp = "54510157-34ba-5bae-9679-8796fd194225" },
              new ApplicationUser() { Id = "8aee2ac4-ff3b-6790-83ek-11c11c1e2bb56", UserName = "MCQStudent10", NormalizedUserName = "MCQSTUDENT10", PasswordHash = "AQAAAAEAACcQAAAAEMwir2Ry6QPjmxbX2uvOvURQl64u1tO9Iq79RopAbKEvNKi7CjX8F6BIB0wRmJUMsQ==", SecurityStamp = "J3UOJJDKHP3KDBKRBAKD29OGFNRAVCZ10", ConcurrencyStamp = "54510157-34ba-5bad-9679-8796fd194226" },
              new ApplicationUser() { Id = "8aee2ac4-ff3b-6791-83el-12c11c1e2bb57", UserName = "MCQStudent11", NormalizedUserName = "MCQSTUDENT11", PasswordHash = "AQAAAAEAACcQAAAAEMwir2Ry6QPjmxbX2uvOvURQl64u1tO9Iq79RopAbKEvNKi7CjX8F6BIB0wRmJUMsQ==", SecurityStamp = "K3UOJJDKHP3KDBKRBAKD29OGFNRAVCZ11", ConcurrencyStamp = "54510157-34ba-5bac-9679-8796fd194227" },
              new ApplicationUser() { Id = "8aee2ac4-ff3b-6792-83em-13c11c1e2bb58", UserName = "MCQStudent12", NormalizedUserName = "MCQSTUDENT12", PasswordHash = "AQAAAAEAACcQAAAAEMwir2Ry6QPjmxbX2uvOvURQl64u1tO9Iq79RopAbKEvNKi7CjX8F6BIB0wRmJUMsQ==", SecurityStamp = "L3UOJJDKHP3KDBKRBAKD29OGFNRAVCZ12", ConcurrencyStamp = "54510157-34ba-5bab-9679-8796fd194228" },
              new ApplicationUser() { Id = "8aee2ac4-ff3b-6793-83em-13c11c1e2bb59", UserName = "MCQStudent13", NormalizedUserName = "MCQSTUDENT13", PasswordHash = "AQAAAAEAACcQAAAAEMwir2Ry6QPjmxbX2uvOvURQl64u1tO9Iq79RopAbKEvNKi7CjX8F6BIB0wRmJUMsQ==", SecurityStamp = "L3UOJJDKHP3KDBKRBAKD29OGFNRAVCZ13", ConcurrencyStamp = "54510157-34ba-5bab-9679-8796fd194229" },
              new ApplicationUser() { Id = "8aee2ac4-ff3b-6794-83em-13c11c1e2bb60", UserName = "MCQStudent14", NormalizedUserName = "MCQSTUDENT14", PasswordHash = "AQAAAAEAACcQAAAAEMwir2Ry6QPjmxbX2uvOvURQl64u1tO9Iq79RopAbKEvNKi7CjX8F6BIB0wRmJUMsQ==", SecurityStamp = "L3UOJJDKHP3KDBKRBAKD29OGFNRAVCZ14", ConcurrencyStamp = "54510157-34ba-5bab-9679-8796fd194230" },
              new ApplicationUser() { Id = "8aee2ac4-ff3b-6795-83em-13c11c1e2bb61", UserName = "MCQStudent15", NormalizedUserName = "MCQSTUDENT15", PasswordHash = "AQAAAAEAACcQAAAAEMwir2Ry6QPjmxbX2uvOvURQl64u1tO9Iq79RopAbKEvNKi7CjX8F6BIB0wRmJUMsQ==", SecurityStamp = "L3UOJJDKHP3KDBKRBAKD29OGFNRAVCZ15", ConcurrencyStamp = "54510157-34ba-5bab-9679-8796fd194231" },
              new ApplicationUser() { Id = "8aee2ac4-ff3b-6796-83em-13c11c1e2bb62", UserName = "MCQStudent16", NormalizedUserName = "MCQSTUDENT16", PasswordHash = "AQAAAAEAACcQAAAAEMwir2Ry6QPjmxbX2uvOvURQl64u1tO9Iq79RopAbKEvNKi7CjX8F6BIB0wRmJUMsQ==", SecurityStamp = "L3UOJJDKHP3KDBKRBAKD29OGFNRAVCZ16", ConcurrencyStamp = "54510157-34ba-5bab-9679-8796fd194232" },
              new ApplicationUser() { Id = "8aee2ac4-ff3b-6797-83em-13c11c1e2bb63", UserName = "MCQStudent17", NormalizedUserName = "MCQSTUDENT17", PasswordHash = "AQAAAAEAACcQAAAAEMwir2Ry6QPjmxbX2uvOvURQl64u1tO9Iq79RopAbKEvNKi7CjX8F6BIB0wRmJUMsQ==", SecurityStamp = "L3UOJJDKHP3KDBKRBAKD29OGFNRAVCZ17", ConcurrencyStamp = "54510157-34ba-5bab-9679-8796fd194233" },
              new ApplicationUser() { Id = "8aee2ac4-ff3b-6798-83em-13c11c1e2bb64", UserName = "MCQStudent18", NormalizedUserName = "MCQSTUDENT18", PasswordHash = "AQAAAAEAACcQAAAAEMwir2Ry6QPjmxbX2uvOvURQl64u1tO9Iq79RopAbKEvNKi7CjX8F6BIB0wRmJUMsQ==", SecurityStamp = "L3UOJJDKHP3KDBKRBAKD29OGFNRAVCZ18", ConcurrencyStamp = "54510157-34ba-5bab-9679-8796fd194234" }
             );

        }

        //Application DbContext
        public DbSet<Exam> Exams { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<BuzzerTime> BuzzerTimes { get; set; }
        public DbSet<BuzzerMark> BuzzerMarks { get; set; }
        public DbSet<McqMark> McqMarks { get; set; }

    }
}
