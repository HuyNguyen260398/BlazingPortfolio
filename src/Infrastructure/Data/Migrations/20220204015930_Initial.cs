using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data
{
    public partial class Initial : Migration
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
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    DoB = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
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
                values: new object[] { 1, "05b5a988-4c4b-4cc0-9800-aaa8af8dd806", "", ".png", "", "" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "ImageGuid", "NewImageBase64Content", "NewImageExtension", "OldImagePath", "RelativeImagePath" },
                values: new object[] { 2, "b5c1a3f3-5938-4e07-9e66-14e292ac7524", "", ".png", "", "" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "ImageGuid", "NewImageBase64Content", "NewImageExtension", "OldImagePath", "RelativeImagePath" },
                values: new object[] { 3, "3a6f082a-1f04-46e1-92e4-eea7016163a9", "", ".png", "", "" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Content", "Excerpt", "IsPublished", "PublishDate", "ThumbnailPath", "Title" },
                values: new object[] { 1, "Content 1", "Excerpt 1", true, new DateTime(2022, 2, 4, 0, 0, 0, 0, DateTimeKind.Local), "", "Post 1" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Content", "Excerpt", "IsPublished", "PublishDate", "ThumbnailPath", "Title" },
                values: new object[] { 2, "Content 2", "Excerpt 2", true, new DateTime(2022, 2, 4, 0, 0, 0, 0, DateTimeKind.Local), "", "Post 2" });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Content", "Excerpt", "IsPublished", "PublishDate", "ThumbnailPath", "Title" },
                values: new object[] { 3, "Content 3", "Excerpt 3", true, new DateTime(2022, 2, 4, 0, 0, 0, 0, DateTimeKind.Local), "", "Post 3" });

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
                table: "Users",
                columns: new[] { "UserId", "Address", "AvatarImagePath", "BackgroundImagePath", "Degree", "DoB", "Email", "FirstName", "Interests", "Intro", "LastName", "Phone", "Study" },
                values: new object[] { 1, "HCM City, Viet Nam", "uploads/avatar.jpg", "uploads/ocean_background.jpg", "Bachelor of Computer Science", new DateTime(1998, 3, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "huynguyen260398@gmail.com", "Huy", "Building websites", "I am a Web Developer, and I'm very passionate and dedicated to my work. With 2 years experience as a senior Web developer, I have acquired the skills and knowledge necessary to make your project a success.", "Nguyen", "(+84)903336493", "University of Greenwich" });
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
                name: "Users");
        }
    }
}
