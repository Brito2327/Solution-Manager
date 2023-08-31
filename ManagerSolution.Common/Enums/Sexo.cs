//-----------------------------------------------------------------------
// <copyright file="Sexo.cs" company="Bludata Software">
//     Copyright (c) Bludata Software. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CooperDesp.Common
{
    using System.ComponentModel;

    /// <summary>
    /// Sexo
    /// </summary>
    public enum Sexo
    {
        /// <summary>
        /// Não informado.
        /// </summary>
        [Description("Não Informado")]
        NaoInformado = 0,

        /// <summary>
        /// Masculino.
        /// </summary>
        [Description("Masculino")]
        Masculino = 1,

        /// <summary>
        /// Feminino.
        /// </summary>
        [Description("Feminino")]
        Feminino = 2
    }
}