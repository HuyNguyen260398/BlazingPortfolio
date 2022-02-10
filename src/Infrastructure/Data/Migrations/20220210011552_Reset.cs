using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    public partial class Reset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Archievements",
                columns: table => new
                {
                    ArchievementId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Count = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archievements", x => x.ArchievementId);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ImageGuid = table.Column<string>(type: "TEXT", nullable: false),
                    NewImageExtension = table.Column<string>(type: "TEXT", nullable: false),
                    NewImageBase64Content = table.Column<string>(type: "TEXT", nullable: false),
                    OldImagePath = table.Column<string>(type: "TEXT", nullable: false),
                    RelativeImagePath = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImageId);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    ThumbnailPath = table.Column<string>(type: "TEXT", nullable: false),
                    Excerpt = table.Column<string>(type: "TEXT", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    IsPublished = table.Column<bool>(type: "INTEGER", nullable: false),
                    PublishDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.PostId);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    SvgPath = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceId);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    SkillId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    YearsOfExperience = table.Column<int>(type: "INTEGER", nullable: false),
                    ScorePercentage = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    DoB = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Address = table.Column<string>(type: "TEXT", nullable: false),
                    Study = table.Column<string>(type: "TEXT", nullable: false),
                    Degree = table.Column<string>(type: "TEXT", nullable: false),
                    Interests = table.Column<string>(type: "TEXT", nullable: false),
                    Intro = table.Column<string>(type: "TEXT", nullable: false),
                    AvatarImagePath = table.Column<string>(type: "TEXT", nullable: false),
                    BackgroundImagePath = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "Archievements",
                columns: new[] { "ArchievementId", "Count", "Name" },
                values: new object[] { 1, 111, "Happy Clients" });

            migrationBuilder.InsertData(
                table: "Archievements",
                columns: new[] { "ArchievementId", "Count", "Name" },
                values: new object[] { 2, 333, "Projects Finished" });

            migrationBuilder.InsertData(
                table: "Archievements",
                columns: new[] { "ArchievementId", "Count", "Name" },
                values: new object[] { 3, 777, "Awards Won" });

            migrationBuilder.InsertData(
                table: "Archievements",
                columns: new[] { "ArchievementId", "Count", "Name" },
                values: new object[] { 4, 555, "Certificates Archieved" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "ImageGuid", "NewImageBase64Content", "NewImageExtension", "OldImagePath", "RelativeImagePath" },
                values: new object[] { 1, "0ed4ebf5-0b51-43e5-bd77-0b514a4900fd", "", ".png", "", "" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "ImageGuid", "NewImageBase64Content", "NewImageExtension", "OldImagePath", "RelativeImagePath" },
                values: new object[] { 2, "050f0a10-9f36-422c-b676-fd95b582d996", "", ".png", "", "" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "ImageGuid", "NewImageBase64Content", "NewImageExtension", "OldImagePath", "RelativeImagePath" },
                values: new object[] { 3, "8e8b849e-145d-4c47-a4ca-f6e6d9f5cfc3", "", ".png", "", "" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Content", "Excerpt", "IsPublished", "PublishDate", "ThumbnailPath", "Title" },
                values: new object[] { 1, "Content 1", "Excerpt 1", true, new DateTime(2022, 2, 10, 0, 0, 0, 0, DateTimeKind.Local), "", "Post 1" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Content", "Excerpt", "IsPublished", "PublishDate", "ThumbnailPath", "Title" },
                values: new object[] { 2, "Content 2", "Excerpt 2", true, new DateTime(2022, 2, 10, 0, 0, 0, 0, DateTimeKind.Local), "", "Post 2" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Content", "Excerpt", "IsPublished", "PublishDate", "ThumbnailPath", "Title" },
                values: new object[] { 3, "Content 3", "Excerpt 3", true, new DateTime(2022, 2, 10, 0, 0, 0, 0, DateTimeKind.Local), "", "Post 3" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "Description", "Name", "SvgPath" },
                values: new object[] { 1, "Building web apps with DotNet", "Web Developement", "uploads/code.svg" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "Description", "Name", "SvgPath" },
                values: new object[] { 2, "Upscaling apps using DevOps stacks", "DevOps", "uploads/telegram.svg" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "Description", "Name", "SvgPath" },
                values: new object[] { 3, "Visualizing data by Power Bi", "Data Analysist", "uploads/creativity.svg" });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "Name", "ScorePercentage", "YearsOfExperience" },
                values: new object[] { 1, "C#", 0.9m, 3 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "Name", "ScorePercentage", "YearsOfExperience" },
                values: new object[] { 2, "SQL", 0.5m, 1 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "Name", "ScorePercentage", "YearsOfExperience" },
                values: new object[] { 3, "DotNet", 0.7m, 2 });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "SkillId", "Name", "ScorePercentage", "YearsOfExperience" },
                values: new object[] { 4, "Blazor", 0.7m, 2 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Address", "AvatarImagePath", "BackgroundImagePath", "Degree", "DoB", "Email", "FirstName", "Interests", "Intro", "LastName", "Password", "Phone", "Study" },
                values: new object[] { 1, "HCM City, Viet Nam", "uploads/avatar.jpg", "uploads/ocean_background.jpg", "Bachelor of Computer Science", new DateTime(1998, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "huynguyen260398@gmail.com", "Huy", "Building websites", "I am a Web Developer, and I'm very passionate and dedicated to my work. With 2 years experience as a senior Web developer, I have acquired the skills and knowledge necessary to make your project a success.", "Nguyen", "Pas$w0rd", "(+84)903336493", "University of Greenwich" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Archievements");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
