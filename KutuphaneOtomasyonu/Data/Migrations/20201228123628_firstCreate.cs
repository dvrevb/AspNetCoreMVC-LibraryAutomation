using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KutuphaneOtomasyonu.Data.Migrations
{
    public partial class firstCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dil",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DilAd = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dil", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EpostaAdresi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    epostaAdresi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpostaAdresi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TelefonNumarasi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    telefonNumarasi = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelefonNumarasi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tur",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TurAd = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tur", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Yayinevi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yayinevi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Yazar",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(nullable: true),
                    Soyad = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yazar", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KisiselBilgiler",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(maxLength: 30, nullable: true),
                    Soyad = table.Column<string>(maxLength: 30, nullable: true),
                    Cinsiyet = table.Column<int>(nullable: false),
                    DogumTarihi = table.Column<DateTime>(nullable: true),
                    TelefonId = table.Column<int>(nullable: false),
                    EPostaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KisiselBilgiler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KisiselBilgiler_EpostaAdresi_EPostaId",
                        column: x => x.EPostaId,
                        principalTable: "EpostaAdresi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KisiselBilgiler_TelefonNumarasi_TelefonId",
                        column: x => x.TelefonId,
                        principalTable: "TelefonNumarasi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SureliYayin",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ISBN = table.Column<string>(nullable: true),
                    EserAdi = table.Column<string>(nullable: true),
                    BaskiSayisi = table.Column<int>(nullable: true),
                    SayfaSayisi = table.Column<int>(nullable: true),
                    Kapak = table.Column<string>(nullable: true),
                    Icerik = table.Column<string>(nullable: true),
                    TurId = table.Column<int>(nullable: false),
                    YayineviId = table.Column<int>(nullable: false),
                    DilId = table.Column<int>(nullable: false),
                    Tarih = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SureliYayin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SureliYayin_Dil_DilId",
                        column: x => x.DilId,
                        principalTable: "Dil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SureliYayin_Tur_TurId",
                        column: x => x.TurId,
                        principalTable: "Tur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SureliYayin_Yayinevi_YayineviId",
                        column: x => x.YayineviId,
                        principalTable: "Yayinevi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Kitap",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ISBN = table.Column<string>(nullable: true),
                    EserAdi = table.Column<string>(nullable: true),
                    BaskiSayisi = table.Column<int>(nullable: true),
                    SayfaSayisi = table.Column<int>(nullable: true),
                    Kapak = table.Column<string>(nullable: true),
                    Icerik = table.Column<string>(nullable: true),
                    TurId = table.Column<int>(nullable: false),
                    YayineviId = table.Column<int>(nullable: false),
                    DilId = table.Column<int>(nullable: false),
                    YazarId = table.Column<int>(nullable: false),
                    OduncDurumu = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kitap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kitap_Dil_DilId",
                        column: x => x.DilId,
                        principalTable: "Dil",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kitap_Tur_TurId",
                        column: x => x.TurId,
                        principalTable: "Tur",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kitap_Yayinevi_YayineviId",
                        column: x => x.YayineviId,
                        principalTable: "Yayinevi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Kitap_Yazar_YazarId",
                        column: x => x.YazarId,
                        principalTable: "Yazar",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KisiselBilgiler_EPostaId",
                table: "KisiselBilgiler",
                column: "EPostaId");

            migrationBuilder.CreateIndex(
                name: "IX_KisiselBilgiler_TelefonId",
                table: "KisiselBilgiler",
                column: "TelefonId");

            migrationBuilder.CreateIndex(
                name: "IX_Kitap_DilId",
                table: "Kitap",
                column: "DilId");

            migrationBuilder.CreateIndex(
                name: "IX_Kitap_TurId",
                table: "Kitap",
                column: "TurId");

            migrationBuilder.CreateIndex(
                name: "IX_Kitap_YayineviId",
                table: "Kitap",
                column: "YayineviId");

            migrationBuilder.CreateIndex(
                name: "IX_Kitap_YazarId",
                table: "Kitap",
                column: "YazarId");

            migrationBuilder.CreateIndex(
                name: "IX_SureliYayin_DilId",
                table: "SureliYayin",
                column: "DilId");

            migrationBuilder.CreateIndex(
                name: "IX_SureliYayin_TurId",
                table: "SureliYayin",
                column: "TurId");

            migrationBuilder.CreateIndex(
                name: "IX_SureliYayin_YayineviId",
                table: "SureliYayin",
                column: "YayineviId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KisiselBilgiler");

            migrationBuilder.DropTable(
                name: "Kitap");

            migrationBuilder.DropTable(
                name: "SureliYayin");

            migrationBuilder.DropTable(
                name: "EpostaAdresi");

            migrationBuilder.DropTable(
                name: "TelefonNumarasi");

            migrationBuilder.DropTable(
                name: "Yazar");

            migrationBuilder.DropTable(
                name: "Dil");

            migrationBuilder.DropTable(
                name: "Tur");

            migrationBuilder.DropTable(
                name: "Yayinevi");
        }
    }
}
