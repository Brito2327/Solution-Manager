using ManagerSolution.RN.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagerSolution.RN.DTO
{
    public class RetornoMensagem<T>
    {
        public RetornoMensagem(EToastr tipo, string mensagem)
            : this(tipo, mensagem, default(T))
        {
        }

        public RetornoMensagem(EToastr tipo, string mensagem, T objeto)
        {
            Tipo = tipo;
            Mensagem = mensagem;
            Objeto = objeto;
        }

        /// <summary>
        /// Tipo de balão a ser exibido com a mensagem para o usuário.
        /// </summary>
        public EToastr Tipo { get; set; }

        /// <summary>
        /// Mensagem.
        /// </summary>
        public string Mensagem { get; set; }

        /// <summary>
        /// Objeto genérico que pode acompanhar as mensagens.
        /// </summary>
        public T Objeto { get; set; }
    }
    
}