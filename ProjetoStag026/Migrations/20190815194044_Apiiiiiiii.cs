using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoStag026.Migrations
{
    public partial class Apiiiiiiii : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Componente_Paciente_Componente_ComponenteId",
                table: "Componente_Paciente");

            migrationBuilder.DropForeignKey(
                name: "FK_Componente_RemediosContext_Componente_ComponenteId",
                table: "Componente_RemediosContext");

            migrationBuilder.DropForeignKey(
                name: "FK_Componente_RemediosContext_Remedio_RemedioId",
                table: "Componente_RemediosContext");

            migrationBuilder.DropIndex(
                name: "IX_Componente_RemediosContext_ComponenteId",
                table: "Componente_RemediosContext");

            migrationBuilder.DropIndex(
                name: "IX_Componente_Paciente_ComponenteId",
                table: "Componente_Paciente");

            migrationBuilder.DropColumn(
                name: "ComponenteId",
                table: "Componente_RemediosContext");

            migrationBuilder.DropColumn(
                name: "ComponenteId",
                table: "Componente_Paciente");

            migrationBuilder.RenameColumn(
                name: "RemedioId",
                table: "Componente_RemediosContext",
                newName: "PacienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Componente_RemediosContext_RemedioId",
                table: "Componente_RemediosContext",
                newName: "IX_Componente_RemediosContext_PacienteId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Componente_Paciente",
                newName: "ID");

            migrationBuilder.AddColumn<string>(
                name: "Componente",
                table: "Componente_RemediosContext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Componente",
                table: "Componente_Paciente",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Componente_RemediosContext_Paciente_PacienteId",
                table: "Componente_RemediosContext",
                column: "PacienteId",
                principalTable: "Paciente",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Componente_RemediosContext_Paciente_PacienteId",
                table: "Componente_RemediosContext");

            migrationBuilder.DropColumn(
                name: "Componente",
                table: "Componente_RemediosContext");

            migrationBuilder.DropColumn(
                name: "Componente",
                table: "Componente_Paciente");

            migrationBuilder.RenameColumn(
                name: "PacienteId",
                table: "Componente_RemediosContext",
                newName: "RemedioId");

            migrationBuilder.RenameIndex(
                name: "IX_Componente_RemediosContext_PacienteId",
                table: "Componente_RemediosContext",
                newName: "IX_Componente_RemediosContext_RemedioId");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Componente_Paciente",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "ComponenteId",
                table: "Componente_RemediosContext",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ComponenteId",
                table: "Componente_Paciente",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Componente_RemediosContext_ComponenteId",
                table: "Componente_RemediosContext",
                column: "ComponenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Componente_Paciente_ComponenteId",
                table: "Componente_Paciente",
                column: "ComponenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Componente_Paciente_Componente_ComponenteId",
                table: "Componente_Paciente",
                column: "ComponenteId",
                principalTable: "Componente",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Componente_RemediosContext_Componente_ComponenteId",
                table: "Componente_RemediosContext",
                column: "ComponenteId",
                principalTable: "Componente",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Componente_RemediosContext_Remedio_RemedioId",
                table: "Componente_RemediosContext",
                column: "RemedioId",
                principalTable: "Remedio",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
