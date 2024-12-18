using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domiki.Web.Data.Migrations
{
    public partial class AddMarketDomikType2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("DomikTypeLevelResources",
                columns: new[] { "DomikTypeLevelDomikTypeId", "DomikTypeLevelValue", "ResourceTypeId", "Value" },
                values: new object[,] {
                   { 7, 1, 1, 10 },
                   { 7, 2, 1, 20 },
                   { 7, 3, 1, 30 },
                   { 7, 4, 1, 40 },
                   { 7, 5, 1, 50 },
                });

            migrationBuilder.InsertData("DomikTypeLevelReceipts",
                columns: new[] { "DomikTypeLevelDomikTypeId", "DomikTypeLevelValue", "ReceiptId" },
                values: new object[,] {
                   { 7, 1, 6, },
                   { 7, 1, 7, },
                   { 7, 1, 8, },
                   { 7, 1, 9, },

                   { 7, 2, 6, },
                   { 7, 2, 7, },
                   { 7, 2, 8, },
                   { 7, 2, 9, },

                   { 7, 3, 6, },
                   { 7, 3, 7, },
                   { 7, 3, 8, },
                   { 7, 3, 9, },

                   { 7, 4, 6, },
                   { 7, 4, 7, },
                   { 7, 4, 8, },
                   { 7, 4, 9, },

                   { 7, 5, 6, },
                   { 7, 5, 7, },
                   { 7, 5, 8, },
                   { 7, 5, 9, },
                   { 7, 5, 10, },
                   { 7, 5, 11, },
                   { 7, 5, 12, },
                   { 7, 5, 13, },
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
