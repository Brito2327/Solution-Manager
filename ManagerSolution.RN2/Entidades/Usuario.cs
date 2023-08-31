
using ManagerSolution.RN.Enum;

namespace ManagerSolution.RN.Entidades
{
    public class Usuario
    {
        public int ID { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public ECategoriaUsurio Categoria { get; set; }     
    }
}