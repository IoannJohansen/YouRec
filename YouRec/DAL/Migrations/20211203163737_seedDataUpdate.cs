using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class seedDataUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f08ad8e1-e9ac-49e4-80f6-9ed07a854761", "ada1c02d-53bf-40f1-a257-7a62f5a53209" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ada1c02d-53bf-40f1-a257-7a62f5a53209");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45179130-4f5e-4aa5-b1d0-de2a2d618313",
                column: "ConcurrencyStamp",
                value: "6c467eb3-b695-48ae-9063-90537bed3d4e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f08ad8e1-e9ac-49e4-80f6-9ed07a854761",
                column: "ConcurrencyStamp",
                value: "0b7c8aa0-5d5a-44c3-bae2-6d1ada36cd10");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "ImageId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ebdee2b0-1b57-41fb-8dba-c6062faaf79c", 0, "45376e68-f477-415e-94e9-e1f1857007fe", "urecmainkun@mail.ru", false, null, false, null, "URECMAINKUN@MAIL.RU", null, "AQAAAAEAACcQAAAAEEgMErfHzb7jxJM9td0kMJphoEVXQef+mKHOVuEbU/PKvHFCIW8bE9qkR3lQVG4XYQ==", null, false, "06071c6f-c391-43da-8e9a-811b8bafd42c", false, "Admin" });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 3,
                column: "GroupName",
                value: "Anime");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 4,
                column: "GroupName",
                value: "Sport");

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "Id", "GroupName" },
                values: new object[,]
                {
                    { 5, "Technique" },
                    { 6, "Books" },
                    { 7, "Food" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f08ad8e1-e9ac-49e4-80f6-9ed07a854761", "ebdee2b0-1b57-41fb-8dba-c6062faaf79c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f08ad8e1-e9ac-49e4-80f6-9ed07a854761", "ebdee2b0-1b57-41fb-8dba-c6062faaf79c" });

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ebdee2b0-1b57-41fb-8dba-c6062faaf79c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45179130-4f5e-4aa5-b1d0-de2a2d618313",
                column: "ConcurrencyStamp",
                value: "d371fdb5-3101-4140-986e-7c291382774e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f08ad8e1-e9ac-49e4-80f6-9ed07a854761",
                column: "ConcurrencyStamp",
                value: "e8fcbaf6-9148-471f-86c5-3a3a805f7d3c");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "ImageId", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ada1c02d-53bf-40f1-a257-7a62f5a53209", 0, "d57286e3-3dcc-4f14-bbd3-8858e56ca2a6", "urecmainkun@mail.ru", false, null, false, null, "URECMAINKUN@MAIL.RU", null, "AQAAAAEAACcQAAAAECNFCbK79zCNUIUsJsD/smJ4I8c2v2SPvpBIHpFidPE92jmR3z4HlL7Hu4PwpCITmg==", null, false, "5ff82bb6-52a6-48b7-9ce3-82281e489e11", false, "Admin" });

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 3,
                column: "GroupName",
                value: "Smoking");

            migrationBuilder.UpdateData(
                table: "Groups",
                keyColumn: "Id",
                keyValue: 4,
                column: "GroupName",
                value: "Papaya");

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f08ad8e1-e9ac-49e4-80f6-9ed07a854761", "ada1c02d-53bf-40f1-a257-7a62f5a53209" });
        }
    }
}
