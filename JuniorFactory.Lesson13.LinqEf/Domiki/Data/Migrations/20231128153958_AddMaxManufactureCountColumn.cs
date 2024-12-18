using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

#nullable disable

namespace Domiki.Web.Data.Migrations
{
    public partial class AddMaxManufactureCountColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaxManufactureCount",
                table: "DomikTypeLevels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData("DomikTypeLevels", keyColumns: new string[] { "DomikTypeId", "Value" }, keyValues: new object[] { 1, 1 }, "MaxManufactureCount", 1);
            migrationBuilder.UpdateData("DomikTypeLevels", keyColumns: new string[] { "DomikTypeId", "Value" }, keyValues: new object[] { 2, 1 }, "MaxManufactureCount", 1);
            migrationBuilder.UpdateData("DomikTypeLevels", keyColumns: new string[] { "DomikTypeId", "Value" }, keyValues: new object[] { 3, 1 }, "MaxManufactureCount", 1);
            migrationBuilder.UpdateData("DomikTypeLevels", keyColumns: new string[] { "DomikTypeId", "Value" }, keyValues: new object[] { 4, 1 }, "MaxManufactureCount", 1);
            migrationBuilder.UpdateData("DomikTypeLevels", keyColumns: new string[] { "DomikTypeId", "Value" }, keyValues: new object[] { 5, 1 }, "MaxManufactureCount", 1);
            migrationBuilder.UpdateData("DomikTypeLevels", keyColumns: new string[] { "DomikTypeId", "Value" }, keyValues: new object[] { 6, 1 }, "MaxManufactureCount", 1);
            migrationBuilder.UpdateData("DomikTypeLevels", keyColumns: new string[] { "DomikTypeId", "Value" }, keyValues: new object[] { 1, 2 }, "MaxManufactureCount", 1);
            migrationBuilder.UpdateData("DomikTypeLevels", keyColumns: new string[] { "DomikTypeId", "Value" }, keyValues: new object[] { 2, 2 }, "MaxManufactureCount", 1);
            migrationBuilder.UpdateData("DomikTypeLevels", keyColumns: new string[] { "DomikTypeId", "Value" }, keyValues: new object[] { 3, 2 }, "MaxManufactureCount", 1);
            migrationBuilder.UpdateData("DomikTypeLevels", keyColumns: new string[] { "DomikTypeId", "Value" }, keyValues: new object[] { 4, 2 }, "MaxManufactureCount", 1);
            migrationBuilder.UpdateData("DomikTypeLevels", keyColumns: new string[] { "DomikTypeId", "Value" }, keyValues: new object[] { 5, 2 }, "MaxManufactureCount", 1);
            migrationBuilder.UpdateData("DomikTypeLevels", keyColumns: new string[] { "DomikTypeId", "Value" }, keyValues: new object[] { 6, 2 }, "MaxManufactureCount", 1);
            migrationBuilder.UpdateData("DomikTypeLevels", keyColumns: new string[] { "DomikTypeId", "Value" }, keyValues: new object[] { 1, 3 }, "MaxManufactureCount", 2);
            migrationBuilder.UpdateData("DomikTypeLevels", keyColumns: new string[] { "DomikTypeId", "Value" }, keyValues: new object[] { 2, 3 }, "MaxManufactureCount", 2);
            migrationBuilder.UpdateData("DomikTypeLevels", keyColumns: new string[] { "DomikTypeId", "Value" }, keyValues: new object[] { 3, 3 }, "MaxManufactureCount", 2);
            migrationBuilder.UpdateData("DomikTypeLevels", keyColumns: new string[] { "DomikTypeId", "Value" }, keyValues: new object[] { 4, 3 }, "MaxManufactureCount", 2);
            migrationBuilder.UpdateData("DomikTypeLevels", keyColumns: new string[] { "DomikTypeId", "Value" }, keyValues: new object[] { 5, 3 }, "MaxManufactureCount", 2);
            migrationBuilder.UpdateData("DomikTypeLevels", keyColumns: new string[] { "DomikTypeId", "Value" }, keyValues: new object[] { 6, 3 }, "MaxManufactureCount", 2);
            migrationBuilder.UpdateData("DomikTypeLevels", keyColumns: new string[] { "DomikTypeId", "Value" }, keyValues: new object[] { 1, 4 }, "MaxManufactureCount", 2);
            migrationBuilder.UpdateData("DomikTypeLevels", keyColumns: new string[] { "DomikTypeId", "Value" }, keyValues: new object[] { 2, 4 }, "MaxManufactureCount", 2);
            migrationBuilder.UpdateData("DomikTypeLevels", keyColumns: new string[] { "DomikTypeId", "Value" }, keyValues: new object[] { 3, 4 }, "MaxManufactureCount", 2);
            migrationBuilder.UpdateData("DomikTypeLevels", keyColumns: new string[] { "DomikTypeId", "Value" }, keyValues: new object[] { 4, 4 }, "MaxManufactureCount", 2);
            migrationBuilder.UpdateData("DomikTypeLevels", keyColumns: new string[] { "DomikTypeId", "Value" }, keyValues: new object[] { 5, 4 }, "MaxManufactureCount", 2);
            migrationBuilder.UpdateData("DomikTypeLevels", keyColumns: new string[] { "DomikTypeId", "Value" }, keyValues: new object[] { 6, 4 }, "MaxManufactureCount", 2);
            migrationBuilder.UpdateData("DomikTypeLevels", keyColumns: new string[] { "DomikTypeId", "Value" }, keyValues: new object[] { 1, 5 }, "MaxManufactureCount", 3);
            migrationBuilder.UpdateData("DomikTypeLevels", keyColumns: new string[] { "DomikTypeId", "Value" }, keyValues: new object[] { 2, 5 }, "MaxManufactureCount", 3);
            migrationBuilder.UpdateData("DomikTypeLevels", keyColumns: new string[] { "DomikTypeId", "Value" }, keyValues: new object[] { 3, 5 }, "MaxManufactureCount", 3);
            migrationBuilder.UpdateData("DomikTypeLevels", keyColumns: new string[] { "DomikTypeId", "Value" }, keyValues: new object[] { 4, 5 }, "MaxManufactureCount", 3);
            migrationBuilder.UpdateData("DomikTypeLevels", keyColumns: new string[] { "DomikTypeId", "Value" }, keyValues: new object[] { 5, 5 }, "MaxManufactureCount", 3);
            migrationBuilder.UpdateData("DomikTypeLevels", keyColumns: new string[] { "DomikTypeId", "Value" }, keyValues: new object[] { 6, 5 }, "MaxManufactureCount", 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
