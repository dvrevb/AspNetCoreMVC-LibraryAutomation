using Microsoft.EntityFrameworkCore.Migrations;

namespace KutuphaneOtomasyonu.Data.Migrations
{
    public partial class rafEklendi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RafId",
                table: "SureliYayin",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RafId",
                table: "Kitap",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Raf",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RafNo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raf", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SureliYayin_RafId",
                table: "SureliYayin",
                column: "RafId");

            migrationBuilder.CreateIndex(
                name: "IX_Kitap_RafId",
                table: "Kitap",
                column: "RafId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kitap_Raf_RafId",
                table: "Kitap",
                column: "RafId",
                principalTable: "Raf",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SureliYayin_Raf_RafId",
                table: "SureliYayin",
                column: "RafId",
                principalTable: "Raf",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kitap_Raf_RafId",
                table: "Kitap");

            migrationBuilder.DropForeignKey(
                name: "FK_SureliYayin_Raf_RafId",
                table: "SureliYayin");

            migrationBuilder.DropTable(
                name: "Raf");

            migrationBuilder.DropIndex(
                name: "IX_SureliYayin_RafId",
                table: "SureliYayin");

            migrationBuilder.DropIndex(
                name: "IX_Kitap_RafId",
                table: "Kitap");

            migrationBuilder.DropColumn(
                name: "RafId",
                table: "SureliYayin");

            migrationBuilder.DropColumn(
                name: "RafId",
                table: "Kitap");
        }
    }
}
