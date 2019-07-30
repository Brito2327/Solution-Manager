using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoStag026.Models
{
    public class Usuario
    {
        public int ID { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        public Categoria Categoria { get; set; }
        public int CategoriaId { get; set; }
    }
}