//-----------------------------------------------------------------------
// <copyright file="TipoVeiculo.cs" company="Bludata Software">
//     Copyright (c) Bludata Software. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CooperDesp.Common
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// Tipo de veículo
    /// </summary>
    public enum TipoVeiculo
    {
        /// <summary>
        /// Tipo não informado
        /// </summary>
        NaoInformado = 0,

        /// <summary>
        /// Veículo Oficial
        /// </summary>
        Oficial = 1,

        /// <summary>
        /// Outros tipos
        /// </summary>
        Outros = 2
    }
}