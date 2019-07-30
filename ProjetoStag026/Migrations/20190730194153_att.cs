using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoStag026.Migrations
{
    public partial class att : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Plano",
                table: "Atendimentos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Plano",
                table: "Agendamento",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Plano",
                table: "Atendimentos");

            migrationBuilder.DropColumn(
                name: "Plano",
                table: "Agendamento");
        }
    }
}
