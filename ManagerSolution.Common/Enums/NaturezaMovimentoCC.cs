//-----------------------------------------------------------------------
// <copyright file="NaturezaMovimentoCC.cs" company="Bludata Software">
//     Copyright (c) Bludata Software. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace ManagerSolution.Common
{
    using System;
    using System.ComponentModel;
    using System.Runtime.Serialization;

    /// <summary>
    /// Natureza do Movimento na Conta Corrente.
    /// </summary>
    public enum NaturezaMovimentoCC
    {
        /// <summary>
        /// Movimento tipo Crédito
        /// </summary>
        [Description("C")]
        [EnumMember(Value = "C")]
        Credito,

        /// <summary>
        /// Movimento tipo Débito
        /// </summary>
        [Description("D")]
        [EnumMember(Value = "D")]
        Debito
    }
}