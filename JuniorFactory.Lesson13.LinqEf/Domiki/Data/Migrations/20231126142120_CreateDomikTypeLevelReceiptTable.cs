using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domiki.Web.Data.Migrations
{
    public partial class CreateDomikTypeLevelReceiptTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DomikTypeLevelReceipts",
                columns: table => new
                {
                    DomikTypeLevelDomikTypeId = table.Column<int>(type: "int", nullable: false),
                    DomikTypeLevelValue = table.Column<int>(type: "int", nullable: false),
                    ReceiptId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomikTypeLevelReceipts", x => new { x.DomikTypeLevelDomikTypeId, x.DomikTypeLevelValue, x.ReceiptId });
                    table.ForeignKey(
                        name: "FK_DomikTypeLevelReceipts_DomikTypeLevels_DomikTypeLevelDomikTypeId_DomikTypeLevelValue",
                        columns: x => new { x.DomikTypeLevelDomikTypeId, x.DomikTypeLevelValue },
                        principalTable: "DomikTypeLevels",
                        principalColumns: new[] { "DomikTypeId", "Value" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DomikTypeLevelReceipts_Receipts_ReceiptId",
                        column: x => x.ReceiptId,
                        principalTable: "Receipts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DomikTypeLevelReceipts_ReceiptId",
                table: "DomikTypeLevelReceipts",
                column: "ReceiptId");


            migrationBuilder.InsertData("DomikTypeLevelReceipts",
                columns: new[] { "DomikTypeLevelDomikTypeId", "DomikTypeLevelValue", "ReceiptId" },
                values: new object[,] {
                   { 5, 1, 1 },
                   { 5, 2, 1 },
                   { 5, 2, 2 },
                   { 5, 3, 1 },
                   { 5, 3, 2 },
                   { 5, 4, 1 },
                   { 5, 4, 2 },
                   { 5, 5, 1 },
                   { 5, 5, 2 },

                   { 4, 1, 3 },
                   { 4, 2, 3 },
                   { 4, 3, 3 },
                   { 4, 4, 3 },
                   { 4, 5, 3 },
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DomikTypeLevelReceipts");
        }
    }
}
