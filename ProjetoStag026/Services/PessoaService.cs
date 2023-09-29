using ManagerSolution.DAO;
using ManagerSolution.Models;
using System.Web;

namespace ManagerSolution.Sevices.PessoaService
{
    public class PessoaService
    {
        public PessoaService()
        {

        }

        public bool Cadastrar(Paciente paciente, Endereco endereco, Usuario usuario, HttpPostedFileBase Imagem)
        {
            


            //adicionando o id

            //us.Cadastrar(usuario);
            //end.Cadastrar(endereco);
            //if (Imagem == null)
            //{
            //    paciente.imagem = new byte[0];
            //}
            //else
            //{

            //    paciente.imagem = new byte[Imagem.ContentLength];
            //    Imagem.InputStream.Read(paciente.imagem, 0, Imagem.ContentLength);
            //}


            ////*-------------*
            //paciente.EnderecoId = endereco.ID;
            //paciente.UsuarioId = usuario.ID;

            //Aplicando à instancia
            //pa.Cadastrar(paciente);
            return true;
        }
    }
}