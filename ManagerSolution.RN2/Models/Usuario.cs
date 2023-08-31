using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ManagerSolution.RN2.Models
{
    [Table("Usuario", Schema = "sm-local")]
    public class Usuario
    {
        public long ID { get; set; }
        public string User { get; set; }
        public string Password { get; set; }
        //public Categoria Categoria { get; set; }
        public int Categoria { get; set; }
    }
}