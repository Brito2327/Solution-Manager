using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagerSolution.RN.Enum
{
    public enum EToastr
    {
        /// <summary>
        /// Mensagem de sucesso(PopUp Verde)
        /// </summary>
        Sucesso = 0,

        /// <summary>
        /// Mensagem de erro(PopUp Vermelho)
        /// </summary>
        Erro = 1,

        /// <summary>
        /// Mensagem de informação(PopUp Azul)
        /// </summary>
        Informacao = 2,

        /// <summary>
        /// Mensagem de aviso(PopUp Laranja)
        /// </summary>
        Aviso = 3,
    }
}