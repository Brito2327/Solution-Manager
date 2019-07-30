using ProjetoStag026.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoStag026.DAO
{
    public class AtendimentosDao
    {


        public bool Cadastrar(Atendimentos obj)
        {
            bool valida = false;
            using (var contexto = new ConecaoContext())
            {

                contexto.Atendimentos.Add(obj);
                contexto.SaveChanges();
                valida = true;
            }
            return valida;
        }

        internal IList<Atendimentos> BuscarPorData(string Data)
        {
            DateTime date = Convert.ToDateTime(Data);
            using (var contexto = new ConecaoContext())
            {
                return contexto.Atendimentos.Where(p => p.data == date).ToList();

            }
        }

        public IList<Atendimentos> Select()
        {
            using (var contexto = new ConecaoContext())
            {
                return contexto.Atendimentos.ToList();
            }

        }
        //public void Alterar(Atendimentos obj)
        //{
        //    foreach (var item in Select())
        //    {
        //        if (item.Id == obj.Id)
        //        {
        //            using (var contexto = new ConecaoContext())
        //            {
        //                item.PacienteId = obj.PacienteId;
        //                item.data = obj.data;
        //                item.MedicoId = obj.MedicoId;
        //                item.PacienteId = obj.PacienteId;

        //                contexto.Atendimentos.Update(item);
        //                contexto.SaveChanges();
        //            }
        //        }
        //    }

        //}
        //public bool excluir(Atendimentos obj)
        //{
        //    bool valida = false;
        //    foreach (var item in Select())
        //    {
        //        if (item.Id == obj.Id)
        //        {
        //            using (var contexto = new ConecaoContext())
        //            {
        //                contexto.Atendimentos.Remove(item);
        //                contexto.SaveChanges();
        //                valida = true;
        //            }
        //        }
        //    }
        //    return valida;
        //}

        public Atendimentos BuscaPorId(int id)
        {
            using (var contexto = new ConecaoContext())
            {
                return contexto.Atendimentos
                    .Where(p => p.Id == id)
                    .FirstOrDefault();
            }
        }


        public IList<Atendimentos> BuscarPorMedico(Medico medico)
        {
            using (var contexto = new ConecaoContext())
            {
                return contexto.Atendimentos.Where(p => p.MedicoId == medico.ID).ToList();

            }
        }
    }
}