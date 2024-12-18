using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domiki.Web.Data.Migrations
{
    public partial class RenameDomik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Domik",
                table: "Domik");

            migrationBuilder.RenameTable(
                name: "Domik",
                newName: "Domiks");

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
