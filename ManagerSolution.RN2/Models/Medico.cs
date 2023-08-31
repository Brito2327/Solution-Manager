using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ManagerSolution.RN.Models
{
    [Table("Medico", Schema = "sm-local")]
    public class Medico
    {
        public int ID { get; set; }
        public string nome { get; set; }
        public String CRM { get; set; }
        public string Situacao { get; set; }
        public string AreaDeAtuacao { get; set; }
        public Usuario Usuario { get; set; }
        public long UsuarioId { get; set; }



        //public void Gravar()
        //{
        //    var sql = "";

        //    using (var con = new ConexaoSqlServer())
        //}

    }
}