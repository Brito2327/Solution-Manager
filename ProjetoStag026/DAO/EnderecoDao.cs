using ManagerSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagerSolution.DAO
{
    public class EnderecoDao
    {
       
            public void Cadastrar(Endereco endereco)
            {
                using (var contexto = new GetConexao())
                {

                    contexto.Endereco.Add(endereco);
                    contexto.SaveChanges();
                }

            }

            public IList<Endereco> Select()
            {
                using (var contexto = new GetConexao())
                {
                    return contexto.Endereco.ToList();
                }

            }
            public void Alterar(Endereco endereco)
            {
                foreach (var item in Select())
                {
                    if (item.ID == endereco.ID)
                    {
                        using (var contexto = new GetConexao())
                        {
                        item.rua = endereco.rua;
                        item.Bairro = endereco.Bairro;
                        item.Numero = endereco.Numero;
                        item.Cidade = endereco.Cidade;
                       
                        contexto.Endereco.Update(item);
                            contexto.SaveChanges();
                        }
                    }
                }

            }
            public void excluir(Endereco endereco)
            {
                foreach (var item in Select())
                {
                    if (item.ID == endereco.ID)
                    {
                        using (var contexto = new GetConexao())
                        {
                            contexto.Endereco.Remove(item);
                            contexto.SaveChanges();
                        }
                    }
                }
            }
        public Endereco BuscaPorId(int id)
        {
            using (var contexto = new GetConexao())
            {
                return contexto.Endereco
                    .Where(p => p.ID == id)
                    .FirstOrDefault();
            }
        }
    }
    
}