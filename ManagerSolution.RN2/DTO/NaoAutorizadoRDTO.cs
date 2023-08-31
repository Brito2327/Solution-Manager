using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManagerSolution.DTO
{
    public class NaoAutorizadoRDTO
    {
        /// <summary>
        /// Mensagem
        /// </summary>
        [Required]
        public string Message { get; set; }
    }
}