using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoStag026.Models
{
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