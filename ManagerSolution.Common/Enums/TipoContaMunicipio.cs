//-----------------------------------------------------------------------
// <copyright file="TipoContaMunicipio.cs" company="Bludata Software">
//     Copyright (c) Bludata Software. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CooperDesp.Common
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// Tipo de Conta do Município, para fazer TED.
    /// </summary>
    public enum TipoContaMunicipio
    {
        /// <summary>
        /// Conta do Tipo IPVA
        /// </summary>
        [Description("IPVA")]
        Ipva = 1,

        /// <summary>
        /// Conta do Tipo Multa
        /// </summary>
        [Description("Multa")]
        Multa = 2,

        /// <summary>
        /// Conta de Todos os Tipos (IPVA e Multa)
        /// </summary>
        [Description("Todos")]
        Todos = Ipva | Multa,

        /// <summary>
        /// Conta de Repasse de Multas Online SP
        /// </summary>
        [Description("Tributos")]
        Tributos = 4,
    }
}