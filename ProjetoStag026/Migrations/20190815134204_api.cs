using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoStag026.Migrations
{
    public partial class api : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PrincipioAtivo",
                table: "Remedio",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrincipioAtivo",
                table: "Remedio");
        }
    }
}
