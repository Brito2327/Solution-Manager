using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagerSolution.Models
{
    public class Atendimentos
    {
        public int Id { get; set; }
        public DateTime data { get; set; }
        public Paciente Paciente { get; set; }
        public int PacienteId { get; set; }
        public Medico Medico { get; set; }
        public int MedicoId { get; set; }
        public string Plano { get; set; }
    }
}