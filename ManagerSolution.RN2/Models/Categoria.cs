using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagerSolution.RN.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public bool Medico { get; set; }
        public bool Paciente { get; set; }
        public bool Atendente { get; set; }

    }
}