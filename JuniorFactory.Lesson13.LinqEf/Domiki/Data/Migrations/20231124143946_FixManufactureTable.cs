using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domiki.Web.Data.Migrations
{
    public partial class FixManufactureTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Manufactures_Domiks_DomikPlayerId_DomikId1",
                table: "Manufactures");

            migrationBuilder.DropIndex(
                name: "IX_Manufactures_DomikPlayerId_DomikId1",
                table: "Manufactures");

            migrationBuilder.DropColumn(
                name: "DomikId1",
                table: "Manufactures");

            migrationBuilder.AlterColumn<int>(
                name: "DomikPlayerId",
                table: "Manufactures",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Manufactures_DomikId_DomikPlayerId",
                table: "Manufactures",
                columns: new[] { "DomikId", "DomikPlayerId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Manufactures_Domiks_DomikId_DomikPlayerId",
                table: "Manufactures",
                columns: new[] { "DomikId", "DomikPlayerId" },
                principalTable: "Domiks",
                principalColumns: new[] { "PlayerId", "Id" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
