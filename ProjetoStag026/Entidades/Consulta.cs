using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoStag026.Models
{
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