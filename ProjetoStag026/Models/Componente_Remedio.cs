using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagerSolution.Models
{
    public class Componente_Remedio
    {
        public int ID { get; set; }
        public string  Componente { get; set; }
        public Paciente Paciente { get; set; }
        public int PacienteId { get; set; }
        
    }
}