using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domiki.Web.Data.Migrations
{
    public partial class Fix2ManufactureTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Manufactures_Domiks_DomikId_DomikPlayerId",
                table: "Manufactures");

            migrationBuilder.DropIndex(
                name: "IX_Manufactures_DomikId_DomikPlayerId",
                table: "Manufactures");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Domiks",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 2)
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "PlayerId",
                table: "Domiks",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 1)
                .OldAnnotation("Relational:ColumnOrder", 2);

            migrationBuilder.CreateIndex(
                name: "IX_Manufactures_DomikPlayerId_DomikId",
                table: "Manufactures",
                columns: new[] { "DomikPlayerId", "DomikId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Manufactures_Domiks_DomikPlayerId_DomikId",
                table: "Manufactures",
                columns: new[] { "DomikPlayerId", "DomikId" },
                principalTable: "Domiks",
                principalColumns: new[] { "PlayerId", "Id" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
