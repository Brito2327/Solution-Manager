using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoStag026.Models
{
    public class Prontuario
    {
        public int ID { get; set; }
        public HistoriaPatologicaPregressa HistoriaPatologicaPregressa { get; set; }
        public int HistoriaPatologicaPregressaId { get; set; }
        public string Observacoes { get; set; }
        public Paciente Paciente { get; set; }
        public int PacienteId { get; set; }
       
    }
}