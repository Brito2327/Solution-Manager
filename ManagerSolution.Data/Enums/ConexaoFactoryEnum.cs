using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerSolution.Data.Enums
{
    public enum ConexaoFactoryEnum
    {
        [Description("Factory usado para conexão com Sybase")]
        iAnywhere = 0,

        [Description("Factory usado para conexão com Sql Server")]
        SqlServer = 1
    }
}
