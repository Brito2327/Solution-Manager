using ManagerSolution.RN.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagerSolution.Entidades
{
    public class Atendente
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
    }
}