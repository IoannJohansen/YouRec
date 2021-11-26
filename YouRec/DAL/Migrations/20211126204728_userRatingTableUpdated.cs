using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class userRatingTableUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRatings");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f08ad8e1-e9ac-49e4-80f6-9ed07a854761", "a81d6952-1d40-44e3-9ddf-cebb636c9138" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a81d6952-1d40-44e3-9ddf-cebb636c9138");

            migrationBuilder.AddColumn<int>(
                name: "AuthorRating",
                table: "Recommends",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Ratings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45179130-4f5e-4aa5-b1d0-de2a2d618313",
                column: "ConcurrencyStamp",
                value: "3321b974-3f32-477d-95fa-1267dbf526e2");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f08ad8e1-e9ac-49e4-80f6-9ed07a854761",
                column: "ConcurrencyStamp",
                value: "41026a65-5755-4cd8-bab5-177b8e5c9137");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "200d7d50-189b-4b9c-8046-9fb9800c7752", 0, "8d525e21-3188-4143-8834-7287ed842392", "urecmainkun@mail.ru", false, false, null, "URECMAINKUN@MAIL.RU", null, "AQAAAAEAACcQAAAAELPqeMhUkVOfr11V7DQLujk2yZQ6ipcTyzGZYDXlt/HgbRH9NunEwK63XIc6fmhLYg==", null, false, "fed450ca-1afb-4644-bc90-284bbb185c29", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f08ad8e1-e9ac-49e4-80f6-9ed07a854761", "200d7d50-189b-4b9c-8046-9fb9800c7752" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f08ad8e1-e9ac-49e4-80f6-9ed07a854761", "200d7d50-189b-4b9c-8046-9fb9800c7752" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "200d7d50-189b-4b9c-8046-9fb9800c7752");

            migrationBuilder.DropColumn(
                name: "AuthorRating",
                table: "Recommends");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Ratings",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "UserRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rate = table.Column<int>(type: "int", nullable: false),
                    RecommendId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRatings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRatings_Recommends_RecommendId",
                        column: x => x.RecommendId,
                        principalTable: "Recommends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45179130-4f5e-4aa5-b1d0-de2a2d618313",
                column: "ConcurrencyStamp",
                value: "da4fdf3e-bc6c-4eb4-824b-02b6c8e4438c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f08ad8e1-e9ac-49e4-80f6-9ed07a854761",
                column: "ConcurrencyStamp",
                value: "b89e84f3-955b-41cd-b2ac-cd2194eebe53");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a81d6952-1d40-44e3-9ddf-cebb636c9138", 0, "43354f54-a2ac-4097-a6b5-e2289c2bb366", "urecmainkun@mail.ru", false, false, null, "URECMAINKUN@MAIL.RU", null, "AQAAAAEAACcQAAAAEAmKiJRksyGEP6yQDC6ZI5OnTewJtd2mkbaCqEN396rH06I9Lbvh4dUC1faH+lIQ7g==", null, false, "f9234a3f-8fd7-43bb-a175-b89dbc53a271", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f08ad8e1-e9ac-49e4-80f6-9ed07a854761", "a81d6952-1d40-44e3-9ddf-cebb636c9138" });

            migrationBuilder.CreateIndex(
                name: "IX_UserRatings_RecommendId",
                table: "UserRatings",
                column: "RecommendId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRatings_UserId",
                table: "UserRatings",
                column: "UserId");
        }
    }
}
