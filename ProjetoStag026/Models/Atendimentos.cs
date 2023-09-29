using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagerSolution.Models
{
    public class Atendimentos
    {
        public long Id { get; set; }
        public DateTime DataHora { get; set; }
        public long PacienteId { get; set; }
        public long MedicoId { get; set; }   
        public string Plano { get; set; }
    }
}