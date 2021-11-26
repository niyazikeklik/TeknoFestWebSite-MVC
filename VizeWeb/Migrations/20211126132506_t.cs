using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VizeWeb.Migrations
{
    public partial class t : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Duyurular",
                columns: table => new
                {
                    DuyuruID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DuyuruBaslik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuyuruAciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuyuruDetayLink = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DuyuruTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Duyurular", x => x.DuyuruID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Duyurular");
        }
    }
}
