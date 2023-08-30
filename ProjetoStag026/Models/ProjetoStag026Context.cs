using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ManagerSolution.Models
{
    public class ManagerSolutionContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ManagerSolutionContext() : base("name=ManagerSolutionContext")
        {
        }

        public System.Data.Entity.DbSet<ManagerSolution.Models.Medico> Medicos { get; set; }

        public System.Data.Entity.DbSet<ManagerSolution.Models.Usuario> Usuarios { get; set; }

        public System.Data.Entity.DbSet<ManagerSolution.Models.Atendimentos> Atendimentos { get; set; }

        public System.Data.Entity.DbSet<ManagerSolution.Models.Paciente> Pacientes { get; set; }
    }
}
