//-----------------------------------------------------------------------
// <copyright file="TipoSeguro.cs" company="Bludata Software">
//     Copyright (c) Bludata Software. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CooperDesp.Common
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// Tipo de Seguro
    /// </summary>
    public enum TipoSeguro
    {
        /// <summary>
        /// Outros.
        /// </summary>
        Outros = 0,

        /// <summary>
        /// Vida em Grupo.
        /// </summary>
        VidaEmGrupo = 1,

        /// <summary>
        /// Vida Individual.
        /// </summary>
        VidaIndividual = 2
    }
}