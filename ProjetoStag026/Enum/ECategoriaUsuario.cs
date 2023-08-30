using System.ComponentModel;

namespace ManagerSolution.Enum
{
    public enum ECategoriaUsurio
    {
        [Description("Usuario do Tipo Medico")]
        Medico = 1,
        [Description("Usuario do Tipo Paciente")]
        Paciente = 2,
        [Description("Usuario do Tipo Atendente")]
        Atendente = 3,
    }
}