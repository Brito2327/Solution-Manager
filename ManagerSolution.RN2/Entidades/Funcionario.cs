﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagerSolution.RN2.Models
{
    public class Funcionario
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public Usuario Usuario { get; set; }
        public int UsuarioId { get; set; }
    }
}