using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VizeWeb.Migrations
{
    public partial class BasvurularEklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Basvurular",
                columns: table => new
                {
                    YarismaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YarismaName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TakimID = table.Column<int>(type: "int", nullable: false),
                    BasvuruTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Basvurular", x => x.YarismaID);
                    table.ForeignKey(
                        name: "FK_Basvurular_Takimlar_TakimID",
                        column: x => x.TakimID,
                        principalTable: "Takimlar",
                        principalColumn: "TakimdId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Basvurular_TakimID",
                table: "Basvurular",
                column: "TakimID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Basvurular");
        }
    }
}
