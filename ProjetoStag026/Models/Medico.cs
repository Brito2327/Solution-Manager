using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoStag026.Models
{
    public class Medico
    {
        public int ID { get; set; }
        public string nome { get; set; }
        public String CRM { get; set; }
        public string Situacao { get; set; }
        public  string AreaDeAtuacao { get; set; }
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }

    }
}