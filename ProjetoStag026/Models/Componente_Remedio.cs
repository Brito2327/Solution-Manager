using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoStag026.Models
{
    public class Componente_Remedio
    {
        public int ID { get; set; }
        public Componente Componente { get; set; }
        public int ComponenteId { get; set; }
        public Remedio Remedio { get; set; }
        public int RemedioId { get; set; }
    }
}