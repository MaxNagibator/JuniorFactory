using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domiki.Web.Data.Migrations
{
    public partial class CreateModificatorTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ModificatorTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogicName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ModificatorTypes", x => x.Id);
                });

            migrationBuilder.InsertData("ModificatorTypes",
                columns: new[] { "Id", "Name", "LogicName" },
                values: new object[,] {
                   { 1, "Работяга", "plodder" },
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
