using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domiki.Web.Data.Migrations
{
    public partial class CreateDomikTypeLevelResourcesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DomikTypeLevelResources",
                columns: table => new
                {
                    DomikTypeLevelDomikTypeId = table.Column<int>(type: "int", nullable: false),
                    DomikTypeLevelValue = table.Column<int>(type: "int", nullable: false),
                    ResourceTypeId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomikTypeLevelResources", x => new { x.DomikTypeLevelDomikTypeId, x.DomikTypeLevelValue, x.ResourceTypeId });
                    table.ForeignKey(
                        name: "FK_DomikTypeLevelResources_DomikTypeLevels_DomikTypeLevelDomikTypeId_DomikTypeLevelValue",
                        columns: x => new { x.DomikTypeLevelDomikTypeId, x.DomikTypeLevelValue },
                        principalTable: "DomikTypeLevels",
                        principalColumns: new[] { "DomikTypeId", "Value" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DomikTypeLevelResources_ResourceTypes_ResourceTypeId",
                        column: x => x.ResourceTypeId,
                        principalTable: "ResourceTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DomikTypeLevelResources_ResourceTypeId",
                table: "DomikTypeLevelResources",
                column: "ResourceTypeId");

            migrationBuilder.InsertData("DomikTypeLevelResources",
                columns: new[] { "DomikTypeLevelDomikTypeId", "DomikTypeLevelValue", "ResourceTypeId", "Value" },
                values: new object[,] {
                   { 1, 1, 1, 10 },
                   { 2, 1, 1, 10 },
                   { 3, 1, 1, 10 },
                   { 4, 1, 1, 10 },
                   { 5, 1, 1, 10 },
                   { 6, 1, 1, 10 },
                   { 1, 2, 1, 20 },
                   { 2, 2, 1, 20 },
                   { 3, 2, 1, 20 },
                   { 4, 2, 1, 20 },
                   { 5, 2, 1, 20 },
                   { 6, 2, 1, 20 },
                   { 1, 3, 1, 30 },
                   { 2, 3, 1, 30 },
                   { 3, 3, 1, 30 },
                   { 4, 3, 1, 30 },
                   { 5, 3, 1, 30 },
                   { 6, 3, 1, 30 },
                   { 1, 4, 1, 40 },
                   { 2, 4, 1, 40 },
                   { 3, 4, 1, 40 },
                   { 4, 4, 1, 40 },
                   { 5, 4, 1, 40 },
                   { 6, 4, 1, 40 },
                   { 1, 5, 1, 50 },
                   { 2, 5, 1, 50 },
                   { 3, 5, 1, 50 },
                   { 4, 5, 1, 50 },
                   { 5, 5, 1, 50 },
                   { 6, 5, 1, 50 },
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
