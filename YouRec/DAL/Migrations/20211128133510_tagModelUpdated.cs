using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class tagModelUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Recommends_RecommendId",
                table: "Tags");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f08ad8e1-e9ac-49e4-80f6-9ed07a854761", "30ff516e-d736-4825-a925-1b22a902df4b" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30ff516e-d736-4825-a925-1b22a902df4b");

            migrationBuilder.AlterColumn<int>(
                name: "RecommendId",
                table: "Tags",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "RecommendTags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagId = table.Column<int>(type: "int", nullable: false),
                    RecommendId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecommendTags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecommendTags_Recommends_RecommendId",
                        column: x => x.RecommendId,
                        principalTable: "Recommends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecommendTags_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_RecommendTags_RecommendId",
                table: "RecommendTags",
                column: "RecommendId");

            migrationBuilder.CreateIndex(
                name: "IX_RecommendTags_TagId",
                table: "RecommendTags",
                column: "TagId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Recommends_RecommendId",
                table: "Tags",
                column: "RecommendId",
                principalTable: "Recommends",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Recommends_RecommendId",
                table: "Tags");

            migrationBuilder.DropTable(
                name: "RecommendTags");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f08ad8e1-e9ac-49e4-80f6-9ed07a854761", "04cc9f90-089b-47df-b0e1-c2c069b905b8" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "04cc9f90-089b-47df-b0e1-c2c069b905b8");

            migrationBuilder.AlterColumn<int>(
                name: "RecommendId",
                table: "Tags",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45179130-4f5e-4aa5-b1d0-de2a2d618313",
                column: "ConcurrencyStamp",
                value: "6c58c265-d822-4f90-ac17-d36fb02ddd5e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f08ad8e1-e9ac-49e4-80f6-9ed07a854761",
                column: "ConcurrencyStamp",
                value: "9887efe0-0fea-4075-9041-37c11d00c1cb");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "30ff516e-d736-4825-a925-1b22a902df4b", 0, "f9dfc88b-80e8-49fb-9a72-892ca1c4f817", "urecmainkun@mail.ru", false, false, null, "URECMAINKUN@MAIL.RU", null, "AQAAAAEAACcQAAAAEFLXdBdqKqsS+pJeovVYEyIeyIlVfcjxinqTaGXsqikNIH0Z/SQ7EiEvlJDYOfRnfw==", null, false, "be19f6f1-41e0-4f9b-9664-75db2231f7ac", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f08ad8e1-e9ac-49e4-80f6-9ed07a854761", "30ff516e-d736-4825-a925-1b22a902df4b" });

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Recommends_RecommendId",
                table: "Tags",
                column: "RecommendId",
                principalTable: "Recommends",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
