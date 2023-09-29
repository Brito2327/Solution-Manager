using ManagerSolution.DAO;
using ManagerSolution.Models;
using System;
using System.Web;

namespace ManagerSolution.Sevices.PessoaService
{
    public class UsuarioService
    {
        public UsuarioService()
        {

        }

        public bool Cadastrar(Pessoa paciente, Endereco endereco, Usuario usuario, HttpPostedFileBase Imagem)
        {
            //iniciando instacia
            PacienteDao pa = new PacienteDao();
            EnderecoDao end = new EnderecoDao();
            UsuarioDao us = new UsuarioDao();


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
    
        public Usuario ValidaLogin(Usuario usuario)
        {
            var usDao = new UsuarioDao();
            //var usuarioValidado = usDao.Busca(usuario.NomeUsuario, usuario.Password);

            var usuarioValidado = new Usuario().BuscaUsuario(usuario.NomeUsuario, usuario.Password);
            if (usuarioValidado == null)
            {
                throw new Exception("Usuario não encontrado");
            }
            return usuarioValidado;
        }
    }
}