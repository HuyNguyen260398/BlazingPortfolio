using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    public partial class UpdatePostImageUserModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Users",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ImageId",
                table: "Posts",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ImageFor",
                table: "Images",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Tooltip",
                table: "Images",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 1,
                columns: new[] { "ImageFor", "ImageGuid", "Tooltip" },
                values: new object[] { "services", "329cf90e-0859-4257-9aa5-8d82bf3eecd1", "service_1_img" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 2,
                columns: new[] { "ImageFor", "ImageGuid", "Tooltip" },
                values: new object[] { "services", "0206d65d-cc81-491f-ab16-6932d32fefa0", "service_2_img" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 3,
                columns: new[] { "ImageFor", "ImageGuid", "Tooltip" },
                values: new object[] { "services", "94a9ca2d-cf7c-4c3e-84d1-266c121a94e0", "service_3_img" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageId", "ImageFor", "ImageGuid", "NewImageBase64Content", "NewImageExtension", "OldImagePath", "RelativeImagePath", "Tooltip" },
                values: new object[] { 4, "services", "dfc79fb8-c079-4189-a512-ee030a86a5c5", "", ".png", "", "", "service_4_img" });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                columns: new[] { "ImageId", "PublishDate" },
                values: new object[] { 1, new DateTime(2022, 2, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                columns: new[] { "ImageId", "PublishDate" },
                values: new object[] { 2, new DateTime(2022, 2, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                columns: new[] { "ImageId", "PublishDate" },
                values: new object[] { 3, new DateTime(2022, 2, 24, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "PostId", "Content", "Excerpt", "ImageId", "IsPublished", "PublishDate", "ThumbnailPath", "Title" },
                values: new object[] { 4, "Content 4", "Excerpt 4", 0, true, new DateTime(2022, 2, 24, 0, 0, 0, 0, DateTimeKind.Local), "", "Post 4" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                column: "Gender",
                value: "Male");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "ImageFor",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Tooltip",
                table: "Images");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 1,
                column: "ImageGuid",
                value: "cce9e9a2-93e9-46d4-a33a-ff7c798f5c12");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 2,
                column: "ImageGuid",
                value: "e0c6f826-f314-4016-a849-ff5f275c7506");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageId",
                keyValue: 3,
                column: "ImageGuid",
                value: "392ad7b4-c809-4609-a40c-ce4e77efc8fb");

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "PublishDate",
                value: new DateTime(2022, 2, 13, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "PublishDate",
                value: new DateTime(2022, 2, 13, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 3,
                column: "PublishDate",
                value: new DateTime(2022, 2, 13, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
