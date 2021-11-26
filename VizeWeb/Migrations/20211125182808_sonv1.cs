using Microsoft.EntityFrameworkCore.Migrations;

namespace VizeWeb.Migrations
{
    public partial class sonv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UyeYas",
                table: "Uyeler");

            migrationBuilder.DropColumn(
                name: "OkulName",
                table: "Takimlar");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UyeYas",
                table: "Uyeler",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "OkulName",
                table: "Takimlar",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
