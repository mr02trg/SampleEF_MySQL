using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SampleEFCore.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyValues",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyValues", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "MyValues",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1L, "Value1" });

            migrationBuilder.InsertData(
                table: "MyValues",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2L, "Value2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyValues");
        }
    }
}
