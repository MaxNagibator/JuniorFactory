using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domiki.Web.Data.Migrations
{
    public partial class AddUpgradeSecondsColumnToDomiksTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Domiks",
                table: "Domiks");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpgradeCalculateDate",
                table: "Domiks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "UpgradeSeconds",
                table: "Domiks",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Domiks",
                table: "Domiks",
                columns: new[] { "PlayerId", "Id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
