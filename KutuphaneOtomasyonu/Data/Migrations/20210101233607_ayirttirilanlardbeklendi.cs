using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KutuphaneOtomasyonu.Data.Migrations
{
    public partial class ayirttirilanlardbeklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ayirttirilanlar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ayirttirmaTarihi = table.Column<DateTime>(nullable: false),
                    KitapId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ayirttirilanlar", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ayirttirilanlar_Kitap_KitapId",
                        column: x => x.KitapId,
                        principalTable: "Kitap",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ayirttirilanlar_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ayirttirilanlar_KitapId",
                table: "Ayirttirilanlar",
                column: "KitapId");

            migrationBuilder.CreateIndex(
                name: "IX_Ayirttirilanlar_UserId",
                table: "Ayirttirilanlar",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ayirttirilanlar");
        }
    }
}
