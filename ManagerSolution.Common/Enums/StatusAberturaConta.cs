//-----------------------------------------------------------------------
// <copyright file="StatusAberturaConta.cs" company="Bludata Software">
//     Copyright (c) Bludata Software. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CooperDesp.Common
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// Status da Abertura de Conta.
    /// </summary>
    public enum StatusAberturaConta
    {
        /// <summary>
        /// Não definido.
        /// </summary>
        NaoDefinido = 0,

        /// <summary>
        /// Em processamento.
        /// </summary>
        EmProcessamento = 1,

        /// <summary>
        /// Conta aberta.
        /// </summary>
        ContaAberta = 2,

        /// <summary>
        /// Abertura cancelada.
        /// </summary>
        Cancelado = 3,

        /// <summary>
        /// É conjuge.
        /// </summary>
        Conjuge = 4
    }
}