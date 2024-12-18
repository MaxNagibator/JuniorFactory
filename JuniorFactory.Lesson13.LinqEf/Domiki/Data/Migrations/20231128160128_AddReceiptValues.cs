using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domiki.Web.Data.Migrations
{
    public partial class AddReceiptValues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Receipts",
                columns: new[] { "Id", "Name", "LogicName", "DurationsSeconds", "PlodderCount" },
                values: new object[,] {
                   { 4, "Подобрать камень","stone_dig", 3600, 1 },
                   { 5, "Срубить сосну","wood_dig", 3600, 1 },
            });

            migrationBuilder.InsertData("DomikTypeLevelReceipts",
                columns: new[] { "DomikTypeLevelDomikTypeId", "DomikTypeLevelValue", "ReceiptId" },
                values: new object[,] {
                   { 6, 1, 5 },
                   { 6, 2, 5 },
                   { 6, 3, 5 },
                   { 6, 4, 5 },
                   { 6, 5, 5 },

                   { 3, 1, 4 },
                   { 3, 2, 4 },
                   { 3, 3, 4 },
                   { 3, 4, 4 },
                   { 3, 5, 4 },
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
