using Microsoft.EntityFrameworkCore.Migrations;

namespace Codebridge_WebApiCore.Api.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dogs",
                columns: table => new
                {
                    name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    color = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    tail_length = table.Column<int>(type: "int", nullable: false),
                    weight = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.name);
                });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "name", "color", "tail_length", "weight" },
                values: new object[] { "Neo", "red & amber", 22, 32 });

            migrationBuilder.InsertData(
                table: "Dogs",
                columns: new[] { "name", "color", "tail_length", "weight" },
                values: new object[] { "Jessy", "black & white", 7, 14 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dogs");
        }
    }
}
