using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VizeWeb.Migrations
{
    public partial class ddd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Takimlar",
                columns: table => new
                {
                    TakimdId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TakimUyeSayisi = table.Column<int>(type: "int", nullable: false),
                    OkulName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Takimlar", x => x.TakimdId);
                });

            migrationBuilder.CreateTable(
                name: "Uyeler",
                columns: table => new
                {
                    UyeOkulNo = table.Column<int>(type: "int", nullable: false),
                    UyeAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UyeYas = table.Column<int>(type: "int", nullable: false),
                    UyeTelNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UyeMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UyeDogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UyeAlan = table.Column<int>(type: "int", nullable: false),
                    TakimID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uyeler", x => x.UyeOkulNo);
                    table.ForeignKey(
                        name: "FK_Uyeler_Takimlar_TakimID",
                        column: x => x.TakimID,
                        principalTable: "Takimlar",
                        principalColumn: "TakimdId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Uyeler_TakimID",
                table: "Uyeler",
                column: "TakimID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Uyeler");

            migrationBuilder.DropTable(
                name: "Takimlar");
        }
    }
}
