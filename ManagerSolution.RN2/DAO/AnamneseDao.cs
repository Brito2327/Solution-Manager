using ManagerSolution.RN.Models;
using System.Collections.Generic;
using System.Linq;

namespace ManagerSolution.RN.DAO
{
    public class AnamneseDao
    {

        public void Cadastrar(Anamnese obj)
        {
            using (var contexto = new ConecaoContext())
            {

                contexto.Anamnese.Add(obj);
                contexto.SaveChanges();
            }

        }

        public IList<Anamnese> Select()
        {
            using (var contexto = new ConecaoContext())
            {
                return contexto.Anamnese.ToList();
            }

        }
        public void Alterar(Anamnese obj)
        {
            foreach (var item in Select())
            {
                if (item.ID == obj.ID)
                {
                    using (var contexto = new ConecaoContext())
                    {
                        item.TPR = obj.TPR;
                        item.QP = obj.QP;
                        item.HDA = obj.HDA;
                        item.Antecedentes = obj.Antecedentes;
                        contexto.Anamnese.Update(item);
                        contexto.SaveChanges();
                    }
                }
            }

        }
        public void excluir(Anamnese obj)
        {
            foreach (var item in Select())
            {
                if (item.ID == obj.ID)
                {
                    using (var contexto = new ConecaoContext())
                    {
                        contexto.Anamnese.Remove(item);
                        contexto.SaveChanges();
                    }
                }
            }


        }
        public Anamnese BuscaPorId(int id)
        {
            using (var contexto = new ConecaoContext())
            {
                return contexto.Anamnese
                    .Where(p => p.ID == id)
                    .FirstOrDefault();
            }
        }
    }
}