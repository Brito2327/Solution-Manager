﻿using ManagerSolution.RN.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagerSolution.RN.DAO
{
    public class ConsultaDao
    {
        public bool Cadastrar(Consulta consulta)
        {
            bool valida = false;
            using (var contexto = new ConecaoContext())
            {

                contexto.Consulta.Add(consulta);
                contexto.SaveChanges();
                valida = true;
            }
            return valida;
        }

        public IList<Consulta> Select()
        {
            using (var contexto = new ConecaoContext())
            {
                return contexto.Consulta.ToList();
            }

        }
        public void Alterar(Consulta consulta)
        {
            foreach (var item in Select())
            {
                if (item.ID == consulta.ID)
                {
                    using (var contexto = new ConecaoContext())
                    {
                        
                        
                        contexto.Consulta.Update(item);
                        contexto.SaveChanges();
                    }
                }
            }

        }
        public void excluir(Consulta obj)
        {
            foreach (var item in Select())
            {
                if (item.ID == obj.ID)
                {
                    using (var contexto = new ConecaoContext())
                    {
                        contexto.Consulta.Remove(item);
                        contexto.SaveChanges();
                    }
                }
            }
        }

        public Consulta BuscaPorId(int id)
        {
            using (var contexto = new ConecaoContext())
            {
                return contexto.Consulta
                    .Where(p => p.ID == id)
                    .FirstOrDefault();
            }
        }

        public IList<Consulta> BuscaPorPaciente(int pacienteId)
        {
            using (var contexto = new ConecaoContext())
            {
                //IList<Consulta> x = contexto.Consulta.Where(p => p.PacienteId == pacienteId).ToList();
                return contexto.Consulta.Where(p => p.PacienteId == pacienteId).ToList(); 

            }
        }
    }
}