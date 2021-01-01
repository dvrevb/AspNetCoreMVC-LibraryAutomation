using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KutuphaneOtomasyonu.Data.Migrations
{
    public partial class oduncKaldirildi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Odunc");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Odunc",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KisiselBilgilerId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    KitapId = table.Column<int>(type: "int", nullable: false),
                    gelecegiTarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    oduncTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    userId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    uzatilabilirMi = table.Column<bool>(type: "bit", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Odunc_KisiselBilgilerId",
                table: "Odunc",
                column: "KisiselBilgilerId");

            migrationBuilder.CreateIndex(
                name: "IX_Odunc_KitapId",
                table: "Odunc",
                column: "KitapId");
        }
    }
}
