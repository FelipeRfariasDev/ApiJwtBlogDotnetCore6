using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiJwtBlogDotnetCore6.Migrations
{
    public partial class UploadArquivoCsvItensUpRela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArquivoId",
                table: "Itens");

            migrationBuilder.DropColumn(
                name: "NomeArquivoEnviado",
                table: "Arquivos");

            migrationBuilder.AddColumn<int>(
                name: "ArquivosId",
                table: "Itens",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NomeArquivoEnviadoUrl",
                table: "Arquivos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Itens_ArquivosId",
                table: "Itens",
                column: "ArquivosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Itens_Arquivos_ArquivosId",
                table: "Itens",
                column: "ArquivosId",
                principalTable: "Arquivos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Itens_Arquivos_ArquivosId",
                table: "Itens");

            migrationBuilder.DropIndex(
                name: "IX_Itens_ArquivosId",
                table: "Itens");

            migrationBuilder.DropColumn(
                name: "ArquivosId",
                table: "Itens");

            migrationBuilder.DropColumn(
                name: "NomeArquivoEnviadoUrl",
                table: "Arquivos");

            migrationBuilder.AddColumn<string>(
                name: "ArquivoId",
                table: "Itens",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NomeArquivoEnviado",
                table: "Arquivos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
