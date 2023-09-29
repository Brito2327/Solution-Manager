using System.ComponentModel;

namespace ManagerSolution.Enum
{
    public enum ECategoriaUsurio
    {
        [Description("Usuario com perfil de acesso total")]
        Administrador = 1,
        [Description("Usuario com perfil de acesso limitado")]
        Cliente = 2,
       
    }
}