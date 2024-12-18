using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domiki.Web.Data.Migrations
{
    public partial class CreateReceiptTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Receipts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogicName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DurationsSeconds = table.Column<int>(type: "int", nullable: false),
                    PlodderCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receipts", x => x.Id);
                });

            migrationBuilder.InsertData("Receipts",
                columns: new[] { "Id", "Name", "LogicName", "DurationsSeconds", "PlodderCount" },
                values: new object[,] {
                   { 1, "Копать глину","clay_dig", 3600, 1 },
                   { 2, "Толпой копать глину","clay_dig_together", 3600, 5 },
                   { 3, "Надоблить золотишка","gold_dig", 3600, 1 },
           });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
