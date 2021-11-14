using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class group_model_updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Recommends_GroupId",
                table: "Recommends");

            migrationBuilder.CreateIndex(
                name: "IX_Recommends_GroupId",
                table: "Recommends",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Recommends_GroupId",
                table: "Recommends");

            migrationBuilder.CreateIndex(
                name: "IX_Recommends_GroupId",
                table: "Recommends",
                column: "GroupId",
                unique: true);
        }
    }
}
