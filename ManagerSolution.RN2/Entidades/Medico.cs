using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagerSolution.RN.Entidades
{
    public class Medico
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public String CRM { get; set; }
        public string Situacao { get; set; }
        public  string AreaDeAtuacao { get; set; }
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }


        //public void Gravar()
        //{
        //    var sql = "";
        //     using(var con = new ConexaoSqlServer())
        //}

    }
}