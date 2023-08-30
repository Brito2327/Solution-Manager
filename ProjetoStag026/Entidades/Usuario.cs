using ManagerSolution.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagerSolution.Entidades
{
    public class Usuario
    {
        public int ID { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public ECategoriaUsurio Categoria { get; set; }     
    }
}