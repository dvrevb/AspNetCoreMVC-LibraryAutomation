using Microsoft.EntityFrameworkCore.Migrations;

namespace KutuphaneOtomasyonu.Data.Migrations
{
    public partial class userLoginsCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EpostaAdresi");

            migrationBuilder.DropTable(
                name: "TelefonNumarasi");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EpostaAdresi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    epostaAdresi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpostaAdresi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TelefonNumarasi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    telefonNumarasi = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelefonNumarasi", x => x.Id);
                });
        }
    }
}
