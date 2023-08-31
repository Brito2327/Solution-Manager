//-----------------------------------------------------------------------
// <copyright file="EstadoCivil.cs" company="Bludata Software">
//     Copyright (c) Bludata Software. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CooperDesp.Common
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// Estado Civil
    /// </summary>
    public enum EstadoCivil
    {
        /// <summary>
        /// Não informado.
        /// </summary>
        [Description("Selecione")]
        NaoInformado = 0,

        /// <summary>
        /// Casado.
        /// </summary>
        [Description("Casado")]
        Casado = 1,

        /// <summary>
        /// Solteiro.
        /// </summary>
        [Description("Solteiro")]
        Solteiro = 2,

        /// <summary>
        /// Viúvo.
        /// </summary>
        [Description("Viúvo")]
        Viuvo = 3,

        /// <summary>
        /// Desquitado.
        /// </summary>
        [Description("Desquitado")]
        Desquitado = 4,

        /// <summary>
        /// Outros.
        /// </summary>
        [Description("Outros")]
        Outros = 5
    }
}