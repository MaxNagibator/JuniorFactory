using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domiki.Web.Data.Migrations
{
    public partial class CreateDomikTypeLevelModificatorTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DomikTypeLevelModificators",
                columns: table => new
                {
                    DomikTypeLevelDomikTypeId = table.Column<int>(type: "int", nullable: false),
                    DomikTypeLevelValue = table.Column<int>(type: "int", nullable: false),
                    ModificatorTypeId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomikTypeLevelModificators", x => new { x.DomikTypeLevelDomikTypeId, x.DomikTypeLevelValue, x.ModificatorTypeId });
                    table.ForeignKey(
                        name: "FK_DomikTypeLevelModificators_DomikTypeLevels_DomikTypeLevelDomikTypeId_DomikTypeLevelValue",
                        columns: x => new { x.DomikTypeLevelDomikTypeId, x.DomikTypeLevelValue },
                        principalTable: "DomikTypeLevels",
                        principalColumns: new[] { "DomikTypeId", "Value" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DomikTypeLevelModificators_ModificatorTypes_ModificatorTypeId",
                        column: x => x.ModificatorTypeId,
                        principalTable: "ModificatorTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DomikTypeLevelModificators_ModificatorTypeId",
                table: "DomikTypeLevelModificators",
                column: "ModificatorTypeId");

            migrationBuilder.InsertData("DomikTypeLevelModificators",
                columns: new[] { "DomikTypeLevelDomikTypeId", "DomikTypeLevelValue", "ModificatorTypeId", "Value" },
                values: new object[,] {
                   { 2, 1, 1, 1 },
                   { 2, 2, 1, 2 },
                   { 2, 3, 1, 3 },
                   { 2, 4, 1, 4 },
                   { 2, 5, 1, 5 },
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
