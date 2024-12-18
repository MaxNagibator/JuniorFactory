using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domiki.Web.Data.Migrations
{
    public partial class AddReceiptColumnToManufacture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResourceCount",
                table: "Manufactures");

            migrationBuilder.RenameColumn(
                name: "ResourceTypeId",
                table: "Manufactures",
                newName: "ReceiptId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
