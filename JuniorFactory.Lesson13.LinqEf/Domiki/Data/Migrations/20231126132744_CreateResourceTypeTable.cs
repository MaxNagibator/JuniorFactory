using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domiki.Web.Data.Migrations
{
    public partial class CreateResourceTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResourceTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogicName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceTypes", x => x.Id);
                });

            migrationBuilder.InsertData("ResourceTypes",
                columns: new[] { "Id", "Name", "LogicName" },
                values: new object[,] {
                   { 1, "Деньга","coin" },
                   { 2, "Камень","stone" },
                   { 3, "Дерево","wood" },
                   { 4, "Глина", "clay"},
                   { 5, "Золото", "gold"},
           });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
