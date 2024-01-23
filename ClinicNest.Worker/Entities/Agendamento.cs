using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicNest.Domain.Entities
{
    [Table("Agendamento", Schema = "sm-local")]
    public class Agendamento
    {
        public long Id { get; set; }
        [ForeignKey("PacienteId")]
        public Paciente Paciente { get; set; }        
        
        public DateTime data { get; set; }

        [ForeignKey("MedicoId")]
        public Medico Medico { get; set; }
       
        public DateTime hora { get; set; }
        public string Observacao { get; set; }
        public string Plano { get; set; }


       
    }
}