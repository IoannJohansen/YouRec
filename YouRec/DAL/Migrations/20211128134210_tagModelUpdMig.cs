using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class tagModelUpdMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Recommends_RecommendId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Tags_RecommendId",
                table: "Tags");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f08ad8e1-e9ac-49e4-80f6-9ed07a854761", "04cc9f90-089b-47df-b0e1-c2c069b905b8" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "04cc9f90-089b-47df-b0e1-c2c069b905b8");

            migrationBuilder.DropColumn(
                name: "RecommendId",
                table: "Tags");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f08ad8e1-e9ac-49e4-80f6-9ed07a854761", "986be3f4-294d-4c66-afe0-edc80abfcfb7" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "986be3f4-294d-4c66-afe0-edc80abfcfb7");

            migrationBuilder.AddColumn<int>(
                name: "RecommendId",
                table: "Tags",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45179130-4f5e-4aa5-b1d0-de2a2d618313",
                column: "ConcurrencyStamp",
                value: "f2e40d52-2b39-4b92-9906-21545fc0223d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f08ad8e1-e9ac-49e4-80f6-9ed07a854761",
                column: "ConcurrencyStamp",
                value: "443cc37e-0f21-42e0-bc3f-ad4526b52e9a");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "04cc9f90-089b-47df-b0e1-c2c069b905b8", 0, "b1337156-09b7-4e0a-9f16-d4de21c1f3fa", "urecmainkun@mail.ru", false, false, null, "URECMAINKUN@MAIL.RU", null, "AQAAAAEAACcQAAAAEMag34njsgqAl0PK1PRBvz2OxV9INoxpt2eGpVRgMbEwBDjMgl45jraGYf5HXuPJlg==", null, false, "7a5b2bf5-3bb0-4966-b737-ae54595e08b3", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f08ad8e1-e9ac-49e4-80f6-9ed07a854761", "04cc9f90-089b-47df-b0e1-c2c069b905b8" });

            migrationBuilder.CreateIndex(
                name: "IX_Tags_RecommendId",
                table: "Tags",
                column: "RecommendId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Recommends_RecommendId",
                table: "Tags",
                column: "RecommendId",
                principalTable: "Recommends",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
