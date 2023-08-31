using System.ComponentModel;

namespace ManagerSolution.Common.Enums
{
    public enum AcaoRealizadaHistorico
    {
        [Description("Create")]
        Create = 1,

        [Description("Read")]
        Read = 2,

        [Description("Update")]
        Update = 3,

        [Description("Delete")]
        Delete = 4
    }
}
