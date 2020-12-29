using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KutuphaneOtomasyonu.Data.Migrations
{
    public partial class addedOduncandYorum : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Odunc",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    oduncTarihi = table.Column<DateTime>(nullable: false),
                    gelecegiTarih = table.Column<DateTime>(nullable: false),
                    uzatilabilirMi = table.Column<bool>(nullable: false),
                    KitapId = table.Column<int>(nullable: false),
                    userId = table.Column<string>(nullable: true),
                    KisiselBilgilerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Odunc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Odunc_AspNetUsers_KisiselBilgilerId",
                        column: x => x.KisiselBilgilerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Odunc_Kitap_KitapId",
                        column: x => x.KitapId,
                        principalTable: "Kitap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Yorum",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Icerik = table.Column<string>(nullable: false),
                    olusturulmaTarihi = table.Column<DateTime>(nullable: false),
                    KitapId = table.Column<int>(nullable: false),
                    userId = table.Column<string>(nullable: true),
                    KisiselBilgilerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yorum", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Yorum_AspNetUsers_KisiselBilgilerId",
                        column: x => x.KisiselBilgilerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Yorum_Kitap_KitapId",
                        column: x => x.KitapId,
                        principalTable: "Kitap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Odunc_KisiselBilgilerId",
                table: "Odunc",
                column: "KisiselBilgilerId");

            migrationBuilder.CreateIndex(
                name: "IX_Odunc_KitapId",
                table: "Odunc",
                column: "KitapId");

            migrationBuilder.CreateIndex(
                name: "IX_Yorum_KisiselBilgilerId",
                table: "Yorum",
                column: "KisiselBilgilerId");

            migrationBuilder.CreateIndex(
                name: "IX_Yorum_KitapId",
                table: "Yorum",
                column: "KitapId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Odunc");

            migrationBuilder.DropTable(
                name: "Yorum");
        }
    }
}
