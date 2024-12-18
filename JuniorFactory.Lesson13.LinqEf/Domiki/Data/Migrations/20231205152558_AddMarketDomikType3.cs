using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domiki.Web.Data.Migrations
{
    public partial class AddMarketDomikType3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData("DomikTypeLevels", keyColumns: new string[] { "DomikTypeId", "Value" }, keyValues: new object[] { 7, 1 }, "MaxManufactureCount", 1);
            migrationBuilder.UpdateData("DomikTypeLevels", keyColumns: new string[] { "DomikTypeId", "Value" }, keyValues: new object[] { 7, 2 }, "MaxManufactureCount", 2);
            migrationBuilder.UpdateData("DomikTypeLevels", keyColumns: new string[] { "DomikTypeId", "Value" }, keyValues: new object[] { 7, 3 }, "MaxManufactureCount", 3);
            migrationBuilder.UpdateData("DomikTypeLevels", keyColumns: new string[] { "DomikTypeId", "Value" }, keyValues: new object[] { 7, 4 }, "MaxManufactureCount", 4);
            migrationBuilder.UpdateData("DomikTypeLevels", keyColumns: new string[] { "DomikTypeId", "Value" }, keyValues: new object[] { 7, 5 }, "MaxManufactureCount", 5);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
