using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoStag026.Models
{
    public class Componente_Paciente
    {
        public int Id { get; set; }
        public Componente componente { get; set; }
        public int ComponenteId { get; set; }
        public Paciente Paciente { get; set; }
        public int PacienteId { get; set; }
            

    }
}