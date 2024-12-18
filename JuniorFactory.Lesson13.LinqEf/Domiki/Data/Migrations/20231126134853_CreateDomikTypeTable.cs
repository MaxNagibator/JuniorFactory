using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domiki.Web.Data.Migrations
{
    public partial class CreateDomikTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DomikTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogicName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomikTypes", x => x.Id);
                });


            migrationBuilder.InsertData("DomikTypes",
                columns: new[] { "Id", "Name", "LogicName", "MaxCount" },
                values: new object[,] {
                   { 1, "Кузница", "forge", 1 },
                   { 2, "Барак", "barracks", 5 },
                   { 3, "Каменоломня", "stone_mine", 2 },
                   { 4, "Золотой рудник", "gold_mine", 2 },
                   { 5, "Глиняный карьер", "clay_mine", 2 },
                   { 6, "Лесопилка", "lumber_mill", 2 },
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
