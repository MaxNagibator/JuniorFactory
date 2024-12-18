using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domiki.Web.Data.Migrations
{
    public partial class AddReceiptResources : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("ReceiptResources",
                columns: new[] { "ReceiptId", "ResourceTypeId", "IsInput", "Value" },
                values: new object[,] {
                   { 4, 1, true, 1 },
                   { 4, 3, false, 1 },
                   { 5, 1, true, 1 },
                   { 5, 5, false, 1 },
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
