using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoStag026.Migrations
{
    public partial class bla : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HistoriaPatologicaPregressaContext_Componente_ComponenteId",
                table: "HistoriaPatologicaPregressaContext");

            migrationBuilder.DropIndex(
                name: "IX_HistoriaPatologicaPregressaContext_ComponenteId",
                table: "HistoriaPatologicaPregressaContext");

            migrationBuilder.DropColumn(
                name: "ComponenteId",
                table: "HistoriaPatologicaPregressaContext");

            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Paciente",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Componente_Paciente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ComponenteId = table.Column<int>(nullable: false),
                    PacienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Componente_Paciente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Componente_Paciente_Componente_ComponenteId",
                        column: x => x.ComponenteId,
                        principalTable: "Componente",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Componente_Paciente_Paciente_PacienteId",
                        column: x => x.PacienteId,
                        principalTable: "Paciente",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Componente_Paciente_ComponenteId",
                table: "Componente_Paciente",
                column: "ComponenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Componente_Paciente_PacienteId",
                table: "Componente_Paciente",
                column: "PacienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Componente_Paciente");

            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Paciente");

            migrationBuilder.AddColumn<int>(
                name: "ComponenteId",
                table: "HistoriaPatologicaPregressaContext",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_HistoriaPatologicaPregressaContext_ComponenteId",
                table: "HistoriaPatologicaPregressaContext",
                column: "ComponenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_HistoriaPatologicaPregressaContext_Componente_ComponenteId",
                table: "HistoriaPatologicaPregressaContext",
                column: "ComponenteId",
                principalTable: "Componente",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
