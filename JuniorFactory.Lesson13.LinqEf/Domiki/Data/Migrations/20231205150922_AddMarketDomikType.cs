using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domiki.Web.Data.Migrations
{
    public partial class AddMarketDomikType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("DomikTypes",
                columns: new[] { "Id", "Name", "LogicName", "MaxCount" },
                values: new object[,] {
                   { 7, "Магазин", "market", 1 },
                });

            migrationBuilder.InsertData("DomikTypeLevels",
                columns: new[] { "DomikTypeId", "Value", "UpgradeSeconds" },
                values: new object[,] {
                   { 7,1,  60 },
                   { 7,2,  300 },
                   { 7,3,  3600 },
                   { 7,4,  36000 },
                   { 7,5,  172800 },
                });

            migrationBuilder.InsertData("Receipts",
                columns: new[] { "Id", "Name", "LogicName", "DurationSeconds", "PlodderCount" },
                values: new object[,] {
                   { 6, "Продать глину","sell_clay", 60, 1 },
                   { 7, "Продать дерево","sell_wood", 60, 1 },
                   { 8, "Продать золото","sell_gold", 60, 1 },
                   { 9, "Продать камень","sell_stone", 60, 1 },
                   { 10, "Продать глину x10","sell_clay_x10", 300, 1 },
                   { 11, "Продать дерево x10","sell_wood_x10", 300, 1 },
                   { 12, "Продать золото x10","sell_gold_x10", 300, 1 },
                   { 13, "Продать камень x10","sell_stone_x10", 300, 1 },
                });

            migrationBuilder.InsertData("ReceiptResources",
                columns: new[] { "ReceiptId", "ResourceTypeId", "IsInput", "Value" },
                values: new object[,] {
                   {  6, 4, true, 1 },
                   {  6, 1, false, 10 },
                   {  7, 3, true, 1 },
                   {  7, 1, false, 10 },
                   {  8, 5, true, 1 },
                   {  8, 1, false, 10 },
                   {  9, 2, true, 1 },
                   {  9, 1, false, 10 },
                   { 10, 4, true, 10 },
                   { 10, 1, false, 100 },
                   { 11, 3, true, 10 },
                   { 11, 1, false, 100 },
                   { 12, 5, true, 10 },
                   { 12, 1, false, 100 },
                   { 13, 2, true, 10 },
                   { 13, 1, false, 100 },
                  });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
