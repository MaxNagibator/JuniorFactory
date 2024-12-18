using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domiki.Web.Data.Migrations
{
    public partial class CreateDomikTypeLevelTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DomikTypeLevels",
                columns: table => new
                {
                    DomikTypeId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false),
                    UpgradeSeconds = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomikTypeLevels", x => new { x.DomikTypeId, x.Value });
                    table.ForeignKey(
                        name: "FK_DomikTypeLevels_DomikTypes_DomikTypeId",
                        column: x => x.DomikTypeId,
                        principalTable: "DomikTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData("DomikTypeLevels",
                columns: new[] { "DomikTypeId", "Value", "UpgradeSeconds" },
                values: new object[,] {
                   { 1, 1, 60 },
                   { 2, 1, 60 },
                   { 3, 1, 60 },
                   { 4, 1, 60 },
                   { 5, 1, 60 },
                   { 6, 1, 60 },
                   { 1, 2, 300 },
                   { 2, 2, 300 },
                   { 3, 2, 300 },
                   { 4, 2, 300 },
                   { 5, 2, 300 },
                   { 6, 2, 300 },
                   { 1, 3, 3600 },
                   { 2, 3, 3600 },
                   { 3, 3, 3600 },
                   { 4, 3, 3600 },
                   { 5, 3, 3600 },
                   { 6, 3, 3600 },
                   { 1, 4, 36000 },
                   { 2, 4, 36000 },
                   { 3, 4, 36000 },
                   { 4, 4, 36000 },
                   { 5, 4, 36000 },
                   { 6, 4, 36000 },
                   { 1, 5, 172800 },
                   { 2, 5, 172800 },
                   { 3, 5, 172800 },
                   { 4, 5, 172800 },
                   { 5, 5, 172800 },
                   { 6, 5, 172800 },
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
