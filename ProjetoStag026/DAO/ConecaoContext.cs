using Microsoft.EntityFrameworkCore;
using ProjetoStag026.Models;
using System;

namespace ProjetoStag026.DAO
{
    public class ConecaoContext : DbContext
    {
        public DbSet<Anamnese> Anamnese{ get; set; }
        public DbSet<Atendente> Atendente{ get; set; }
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Componente> Componente{ get; set; }
        public DbSet<Componente_Remedio> Componente_RemediosContext { get; set; }
        public DbSet<Endereco> Endereco { get; set; }
        public DbSet<HistoriaPatologicaPregressa> HistoriaPatologicaPregressaContext { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<Prontuario> Prontuario { get; set; }
        public DbSet<Remedio> Remedio { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<Agendamento> Agendamento { get; set; }
        public DbSet<Funcionario> Funcionario { get; set; }
        public DbSet<Atendimentos> Atendimentos { get; set; }
        public DbSet<Componente_Paciente> Componente_Paciente { get; set; }


        public ConecaoContext(){
            }

        public ConecaoContext(DbContextOptions<ConecaoContext> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.
                    UseSqlServer("Server=tcp:dbcomponente.database.windows.net,1433;Initial Catalog=sistema;Persist Security Info=False;User ID=alexzao;Password=a1e2i3o4@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }
      
    }
}