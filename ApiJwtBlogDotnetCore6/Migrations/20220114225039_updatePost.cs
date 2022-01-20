using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiJwtBlogDotnetCore6.Migrations
{
    public partial class updatePost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataCadastro",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataCadastro",
                table: "Posts");
        }
    }
}
