using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicNest.Domain.Entities
{
    [Table("Consulta", Schema = "sm-local")]
    public class Consulta
    {
        public int ID { get; set; }
        public DateTime Data { get; set; }
        public Paciente Paciente { get; set; }
        public int PacienteId { get; set; }
        public Medico Medico { get; set; }
        public int MedicoId { get; set; }
        public Anamnese Anamnese { get; set; }
        public int AnamneseId { get; set; }
        public string Observacao { get; set; }

    }
}