using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class imageModelUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f08ad8e1-e9ac-49e4-80f6-9ed07a854761", "986be3f4-294d-4c66-afe0-edc80abfcfb7" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "986be3f4-294d-4c66-afe0-edc80abfcfb7");

            migrationBuilder.RenameColumn(
                name: "Link",
                table: "Images",
                newName: "Original");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45179130-4f5e-4aa5-b1d0-de2a2d618313",
                column: "ConcurrencyStamp",
                value: "a68efa6f-d06a-4427-a2aa-74935638383c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f08ad8e1-e9ac-49e4-80f6-9ed07a854761",
                column: "ConcurrencyStamp",
                value: "2b1407df-f25e-46a6-834f-a01ba90d2935");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9ef8569a-47bc-4870-8fcb-9a31e59ec830", 0, "5b94a058-ae03-4626-b991-d2c085d634ce", "urecmainkun@mail.ru", false, false, null, "URECMAINKUN@MAIL.RU", null, "AQAAAAEAACcQAAAAEBzk/uZ6BGewhOJIJl1yzCghOqo4GRe5R1H2SX2Jp+r/YXIfhpNiDXfxCAlBjGbBkQ==", null, false, "0073069c-ab94-4f16-88d3-5324ae36d7ab", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f08ad8e1-e9ac-49e4-80f6-9ed07a854761", "9ef8569a-47bc-4870-8fcb-9a31e59ec830" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f08ad8e1-e9ac-49e4-80f6-9ed07a854761", "9ef8569a-47bc-4870-8fcb-9a31e59ec830" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9ef8569a-47bc-4870-8fcb-9a31e59ec830");

            migrationBuilder.RenameColumn(
                name: "Original",
                table: "Images",
                newName: "Link");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45179130-4f5e-4aa5-b1d0-de2a2d618313",
                column: "ConcurrencyStamp",
                value: "a6ac4b5e-cf8a-4a93-ad0f-daaf6c52a336");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f08ad8e1-e9ac-49e4-80f6-9ed07a854761",
                column: "ConcurrencyStamp",
                value: "8e251221-ac4c-4b95-b5d6-98389a39d284");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "986be3f4-294d-4c66-afe0-edc80abfcfb7", 0, "09c6d080-f46b-4298-934b-0d76a3ced8ef", "urecmainkun@mail.ru", false, false, null, "URECMAINKUN@MAIL.RU", null, "AQAAAAEAACcQAAAAEPQUpuSGqMPSk66SXErDU22Av9MutwTXCUZPR194Rtv3zsUtYM/QFR57g0FSzNlVJQ==", null, false, "46fae3d2-c115-4c12-a643-8e8d461602f7", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f08ad8e1-e9ac-49e4-80f6-9ed07a854761", "986be3f4-294d-4c66-afe0-edc80abfcfb7" });
        }
    }
}
