using ManagerSolution.DAO;
using ManagerSolution.Models;
using System;
using System.Web;

namespace ManagerSolution.Sevices.AgendamentoService

{
    public class AgendamentoService
    {
        public AgendamentoService()
        {

        }

        public void Cadastrar(Agendamento agendamento)
        {
            try
            {
                new Agendamento().Salvar(agendamento);
            }
            catch (Exception ex )
            {
                throw new Exception(ex.Message);
            }            
            
        }   
       
    }
}