using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class addFKToRating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f08ad8e1-e9ac-49e4-80f6-9ed07a854761", "b0443725-5978-4656-9b60-53c6bbcc9675" });

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Ratings",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
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

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_AspNetUsers_UserId",
                table: "Ratings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Ratings_AspNetUsers_UserId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserId",
                table: "Comments");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "f08ad8e1-e9ac-49e4-80f6-9ed07a854761", "30ff516e-d736-4825-a925-1b22a902df4b" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30ff516e-d736-4825-a925-1b22a902df4b");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Ratings",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Comments",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "45179130-4f5e-4aa5-b1d0-de2a2d618313",
                column: "ConcurrencyStamp",
                value: "51dec82b-9649-4163-89c5-167bfe0b6853");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f08ad8e1-e9ac-49e4-80f6-9ed07a854761",
                column: "ConcurrencyStamp",
                value: "15268a39-6f36-4ee0-bba1-81361094f221");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b0443725-5978-4656-9b60-53c6bbcc9675", 0, "afbae9ab-97a1-409b-ab52-fe5d4ca942da", "urecmainkun@mail.ru", false, false, null, "URECMAINKUN@MAIL.RU", null, "AQAAAAEAACcQAAAAEMHcfo3qtr8h/IURpDBJdxSlanE2/I0Rk6eBoyJj0Im/1Vlv1Ijx7PBAsqw0/gnDQA==", null, false, "6e25bbc9-b7a7-4963-82d4-7f462627fe33", false, "Admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "f08ad8e1-e9ac-49e4-80f6-9ed07a854761", "b0443725-5978-4656-9b60-53c6bbcc9675" });
        }
    }
}
