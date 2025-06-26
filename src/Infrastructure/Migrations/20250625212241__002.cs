using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class _002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "ID_ELEMENTS",
                table: "ELEMENTS");

            migrationBuilder.RenameColumn(
                name: "ID_ELEMENTS",
                table: "ELEMENTS",
                newName: "ID_ELEMENT");

            migrationBuilder.AddPrimaryKey(
                name: "ID_ELEMENT",
                table: "ELEMENTS",
                column: "ID_ELEMENT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "ID_ELEMENT",
                table: "ELEMENTS");

            migrationBuilder.RenameColumn(
                name: "ID_ELEMENT",
                table: "ELEMENTS",
                newName: "ID_ELEMENTS");

            migrationBuilder.AddPrimaryKey(
                name: "ID_ELEMENTS",
                table: "ELEMENTS",
                column: "ID_ELEMENTS");
        }
    }
}
