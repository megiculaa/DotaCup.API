using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotaCup.API.Migrations
{
    /// <inheritdoc />
    public partial class ClipsInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "731cd7a8-f9f6-460b-a0fb-e4face5d7327", "1d18d522-ead7-4eb4-b0d9-716edd1daf4f" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c7c112a1-5ed6-42fe-8c3c-370ca30d703b", "1d18d522-ead7-4eb4-b0d9-716edd1daf4f" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "731cd7a8-f9f6-460b-a0fb-e4face5d7327", "2f35c4d8-4e6c-43ff-bcc6-c63c971c6b33" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c7c112a1-5ed6-42fe-8c3c-370ca30d703b", "2f35c4d8-4e6c-43ff-bcc6-c63c971c6b33" });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "731cd7a8-f9f6-460b-a0fb-e4face5d7327");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "c7c112a1-5ed6-42fe-8c3c-370ca30d703b");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: "1d18d522-ead7-4eb4-b0d9-716edd1daf4f");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: "2f35c4d8-4e6c-43ff-bcc6-c63c971c6b33");

            migrationBuilder.CreateTable(
                name: "Clips",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Url = table.Column<string>(type: "text", nullable: false),
                    ViewCount = table.Column<int>(type: "integer", nullable: false),
                    LikeCount = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clips", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "00165322-252d-4950-a395-04260dddbcc6", null, "Admin", "ADMIN" },
                    { "64f3bf9e-e2f6-49a5-ba87-7990356479b0", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "AvatarUrl", "ConcurrencyStamp", "DiscordName", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PTS", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PlayerPosition", "SecurityStamp", "SteamUrl", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1aca145e-3c21-463f-b1a6-640ea7364e6f", 0, null, "d23e2b21-e73a-49a0-af8a-53270fe0631d", null, "user@gmail.com", true, false, null, "USER@GMAIL.COM", "USER", 0, "AQAAAAIAAYagAAAAEB2pcM9mxBHqaX1gwlaNLw3UvC61KNS2if68shsfTD5e3QIJ4QutJk7mLeBq8q98Xw==", null, true, null, "ecf1e9cb-f324-4b0a-8946-a0d86a3beffb", null, false, "User" },
                    { "8547a95f-d0ac-450c-82cd-988e181c771c", 0, null, "46b65060-4617-46d2-bbcb-cc854379ad24", null, "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN", 0, "AQAAAAIAAYagAAAAEF+k1WJfR2cSde1h4Fv+8OQNIEgHlgc8hSbT3RyT1tVImGt2oVkhtw5dNQiBC0VBYg==", null, true, null, "a1f51759-badd-4081-9a98-1d0dc27dedaf", null, false, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "00165322-252d-4950-a395-04260dddbcc6", "1aca145e-3c21-463f-b1a6-640ea7364e6f" },
                    { "64f3bf9e-e2f6-49a5-ba87-7990356479b0", "1aca145e-3c21-463f-b1a6-640ea7364e6f" },
                    { "00165322-252d-4950-a395-04260dddbcc6", "8547a95f-d0ac-450c-82cd-988e181c771c" },
                    { "64f3bf9e-e2f6-49a5-ba87-7990356479b0", "8547a95f-d0ac-450c-82cd-988e181c771c" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clips");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "00165322-252d-4950-a395-04260dddbcc6", "1aca145e-3c21-463f-b1a6-640ea7364e6f" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "64f3bf9e-e2f6-49a5-ba87-7990356479b0", "1aca145e-3c21-463f-b1a6-640ea7364e6f" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "00165322-252d-4950-a395-04260dddbcc6", "8547a95f-d0ac-450c-82cd-988e181c771c" });

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "64f3bf9e-e2f6-49a5-ba87-7990356479b0", "8547a95f-d0ac-450c-82cd-988e181c771c" });

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "00165322-252d-4950-a395-04260dddbcc6");

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "64f3bf9e-e2f6-49a5-ba87-7990356479b0");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: "1aca145e-3c21-463f-b1a6-640ea7364e6f");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: "8547a95f-d0ac-450c-82cd-988e181c771c");

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "731cd7a8-f9f6-460b-a0fb-e4face5d7327", null, "User", "USER" },
                    { "c7c112a1-5ed6-42fe-8c3c-370ca30d703b", null, "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "AccessFailedCount", "AvatarUrl", "ConcurrencyStamp", "DiscordName", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PTS", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PlayerPosition", "SecurityStamp", "SteamUrl", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1d18d522-ead7-4eb4-b0d9-716edd1daf4f", 0, null, "c08c5a76-fba5-4d8a-9123-2cde25ac1b5e", null, "user@gmail.com", true, false, null, "USER@GMAIL.COM", "USER", 0, "AQAAAAIAAYagAAAAEJHbh+E8wsLZawmaHGCvPsBHwBCvBGS+b61KAA3B4cP2zyzJEoOXArgvQMKWE53pUg==", null, true, null, "1736bcdf-91fd-4290-8eab-2a3633df5f66", null, false, "User" },
                    { "2f35c4d8-4e6c-43ff-bcc6-c63c971c6b33", 0, null, "93acd753-ec5d-4d34-83ea-247b4b7a9f02", null, "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN", 0, "AQAAAAIAAYagAAAAEJl12OZqjPnuu6vCyWwm/wH/dAp10dB0ad/4MOXpaTWDDMdvR9Xk7kVo3moPVZR+3g==", null, true, null, "5b27199c-afd2-4a09-9546-3fbcab96ceee", null, false, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "731cd7a8-f9f6-460b-a0fb-e4face5d7327", "1d18d522-ead7-4eb4-b0d9-716edd1daf4f" },
                    { "c7c112a1-5ed6-42fe-8c3c-370ca30d703b", "1d18d522-ead7-4eb4-b0d9-716edd1daf4f" },
                    { "731cd7a8-f9f6-460b-a0fb-e4face5d7327", "2f35c4d8-4e6c-43ff-bcc6-c63c971c6b33" },
                    { "c7c112a1-5ed6-42fe-8c3c-370ca30d703b", "2f35c4d8-4e6c-43ff-bcc6-c63c971c6b33" }
                });
        }
    }
}
