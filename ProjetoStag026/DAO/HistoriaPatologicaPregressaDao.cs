using ManagerSolution.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagerSolution.DAO
{
    public class HistoriaPatologicaPregressaDao
    {
        public void Cadastrar(HistoriaPatologicaPregressa obj)
        {
            using (var contexto = new ConecaoContext())
            {

                contexto.HistoriaPatologicaPregressaContext.Add(obj);
                contexto.SaveChanges();
            }

        }

        public IList<HistoriaPatologicaPregressa> Select()
        {
            using (var contexto = new ConecaoContext())
            {
                return contexto.HistoriaPatologicaPregressaContext.ToList();
            }

        }
        public void Alterar(HistoriaPatologicaPregressa obj)
        {
            foreach (var item in Select())
            {
                if (item.ID == obj.ID)
                {
                    using (var contexto = new ConecaoContext())
                    {
                        item.HF = obj.HF;
                        item.HistoriaSocial = obj.HistoriaSocial;
                        item.HPP = obj.HPP;
                       

                        contexto.HistoriaPatologicaPregressaContext.Update(item);
                        contexto.SaveChanges();
                    }
                }
            }

        }
        public void excluir(HistoriaPatologicaPregressa obj)
        {
            foreach (var item in Select())
            {
                if (item.ID == obj.ID)
                {
                    using (var contexto = new ConecaoContext())
                    {
                        contexto.HistoriaPatologicaPregressaContext.Remove(item);
                        contexto.SaveChanges();
                    }
                }
            }


        }
        public HistoriaPatologicaPregressa BuscaPorId(int id)
        {
            using (var contexto = new ConecaoContext())
            {
                return contexto.HistoriaPatologicaPregressaContext
                    .Where(p => p.ID == id)
                    .FirstOrDefault();
            }
        }
    }
}