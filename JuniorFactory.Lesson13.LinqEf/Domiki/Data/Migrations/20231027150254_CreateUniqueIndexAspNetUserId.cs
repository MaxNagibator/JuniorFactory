using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domiki.Web.Data.Migrations
{
    public partial class CreateUniqueIndexAspNetUserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Player_AspNetUserId",
                table: "Player",
                column: "AspNetUserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
