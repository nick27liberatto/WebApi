using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class _001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ELEMENTS",
                columns: table => new
                {
                    ID_ELEMENTS = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NAME = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    PASSWORD = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    TEXT = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: true),
                    STATUS = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ID_ELEMENTS", x => x.ID_ELEMENTS);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ELEMENTS");
        }
    }
}
