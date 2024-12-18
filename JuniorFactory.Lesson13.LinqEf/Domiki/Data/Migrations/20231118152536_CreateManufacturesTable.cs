using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domiki.Web.Data.Migrations
{
    public partial class CreateManufacturesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Manufactures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DomikId = table.Column<int>(type: "int", nullable: false),
                    ResourceTypeId = table.Column<int>(type: "int", nullable: false),
                    ResourceCount = table.Column<int>(type: "int", nullable: false),
                    PlodderCount = table.Column<int>(type: "int", nullable: false),
                    DomikPlayerId = table.Column<int>(type: "int", nullable: true),
                    DomikId1 = table.Column<int>(type: "int", nullable: true),
                    FinishDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufactures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manufactures_Domiks_DomikPlayerId_DomikId1",
                        columns: x => new { x.DomikPlayerId, x.DomikId1 },
                        principalTable: "Domiks",
                        principalColumns: new[] { "PlayerId", "Id" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_Manufactures_DomikPlayerId_DomikId1",
                table: "Manufactures",
                columns: new[] { "DomikPlayerId", "DomikId1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Manufactures");
        }
    }
}
