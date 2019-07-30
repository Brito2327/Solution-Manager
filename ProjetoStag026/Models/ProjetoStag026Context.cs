using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ProjetoStag026.Models
{
    public class ProjetoStag026Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ProjetoStag026Context() : base("name=ProjetoStag026Context")
        {
        }

        public System.Data.Entity.DbSet<ProjetoStag026.Models.Medico> Medicos { get; set; }

        public System.Data.Entity.DbSet<ProjetoStag026.Models.Usuario> Usuarios { get; set; }

        public System.Data.Entity.DbSet<ProjetoStag026.Models.Atendimentos> Atendimentos { get; set; }

        public System.Data.Entity.DbSet<ProjetoStag026.Models.Paciente> Pacientes { get; set; }
    }
}
