using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ManagerSolution.RN.Models
{
    [Table("Agendamento", Schema = "sm-local")]
    public class Agendamento
    {
        public int Id { get; set; }
        public Paciente Paciente { get; set; }
        public int PacienteId { get; set; }
        public DateTime data { get; set; }
        public Medico Medico { get; set; }
        public int MedicoId { get; set; }
        public string hora { get; set; }
        public string observacao { get; set; }
        public string Plano { get; set; }
       
    }
}