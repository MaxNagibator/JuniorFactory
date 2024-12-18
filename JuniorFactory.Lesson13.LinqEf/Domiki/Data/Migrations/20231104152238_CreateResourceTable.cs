using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domiki.Web.Data.Migrations
{
    public partial class CreateResourceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Domiks",
                table: "Domiks");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Domiks",
                table: "Domiks",
                columns: new[] { "TypeId", "Id" });

            migrationBuilder.CreateTable(
                name: "Resource",
                columns: table => new
                {
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    PlayerId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resource", x => new { x.PlayerId, x.TypeId });
                    table.ForeignKey(
                        name: "FK_Resource_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
