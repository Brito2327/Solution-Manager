//-----------------------------------------------------------------------
// <copyright file="TipoGARE.cs" company="Bludata Software">
//     Copyright (c) Bludata Software. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CooperDesp.Common
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// Tipo da Guia GARE
    /// </summary>
    public enum TipoGARE : int
    {
        /// <summary>
        /// Demais Receitas
        /// </summary>
        [Description("GARE DR")]
        DR = 0,

        /// <summary>
        /// ICMS
        /// </summary>
        [Description("GARE ICMS")]
        ICMS = 1,

        /// <summary>
        /// ICMS
        /// </summary>
        [Description("GARE IPVA")]
        IPVA = 2,

        /// <summary>
        /// ITCMD
        /// </summary>
        [Description("GARE ITCMD")]
        ITCMD = 3
    }
}