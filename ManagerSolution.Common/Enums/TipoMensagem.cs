//-----------------------------------------------------------------------
// <copyright file="TipoMensagem.cs" company="Bludata Software">
//     Copyright (c) Bludata Software. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CooperDesp.Common
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// Tipo de mensagem que é exibida ao usuário.
    /// </summary>
    public enum TipoMensagem : byte
    {
        /// <summary>
        /// Indica que a mensagem é de Erro
        /// </summary>
        Erro = 0,

        /// <summary>
        /// Indice que a mensagem é de Sucesso
        /// </summary>
        Sucesso = 1,
        
        /// <summary>
        /// Indice que a mensagem é Informativa
        /// </summary>
        Informacao = 2
    }
}