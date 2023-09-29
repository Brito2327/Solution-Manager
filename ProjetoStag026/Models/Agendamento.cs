using ManagerSolution.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ManagerSolution.Models
{
    [Table("Agendamento", Schema = "sm-local")]
    public class Agendamento
    {
        public long Id { get; set; }
        [ForeignKey("PacienteId")]
        public Paciente Paciente { get; set; }        
        
        public DateTime data { get; set; }

        [ForeignKey("MedicoId")]
        public Medico Medico { get; set; }
        //public Medico Medico
        //{
        //    get
        //    {
        //        if (medico == null)
        //        {
        //            return new Medico().BuscaPorId(MedicoId);
        //        }
        //        return medico;
        //    }
        //    set { medico = value; }
        //}
        //public long MedicoId { get; set; }
        public DateTime hora { get; set; }
        public string Observacao { get; set; }
        public string Plano { get; set; }


        public void Salvar(Agendamento consulta)
        {
            using (var con = new GetConexao())
            {
                con.Agendamento.Add(consulta);
                con.SaveChanges();
            }
        }
       

        public IList<Agendamento> Listar()
        {
            using (var con = new GetConexao())
            {
                return con.Agendamento.ToList();
            }
        }
        public void Alterar(Agendamento agendamento)
        {
            using (var con = new GetConexao())
            {
                con.Agendamento.Update(agendamento);
                con.SaveChanges();
            }
        }
        public void excluir(Agendamento agendamento)
        {
            using (var con = new GetConexao())
            {
                con.Agendamento.Remove(con.Agendamento.Where(a => a.Id == agendamento.Id).FirstOrDefault());
                con.SaveChanges();

            }
        }

        public Agendamento BuscaPorId(int id)
        {
            using (var con = new GetConexao())
            {
                return con.Agendamento
                    .Where(p => p.Id == id)
                    .FirstOrDefault();
            }
        }

        public void excluirPorId(int agendamentoId)
        {

            using (var con = new GetConexao())
            {
                con.Agendamento.Remove(con.Agendamento.Where(a => a.Id == agendamentoId).FirstOrDefault());
                con.SaveChanges();
            }
        }

        public IList<Agendamento> BuscarAgendamentos(DateTime Data, Medico medico)
        {
            using (var con = new GetConexao())
            {
                return con.Agendamento.Where(p => p.data == Data && p.Medico.ID == medico.ID).ToList();
            }
        }

        public IList<Agendamento> BuscarAgendamentosPorData(DateTime Data)
        {
            using (var con = new GetConexao())
            {
                return con.Agendamento.Where(p => p.data == Data).ToList();
            }
        }        
        public void AgendamentoPassado()
        {

        }
    }
}