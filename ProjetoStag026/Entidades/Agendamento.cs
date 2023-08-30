using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagerSolution.Entidades

{
    public class Agendamento
    {
        public int Id { get; set; }
        public Paciente Paciente { get; set; }        
        public DateTime Data { get; set; }
        public Medico Medico { get; set; }                
        public string Observacao { get; set; }
        public string Plano { get; set; }
       
    }
}