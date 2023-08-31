//-----------------------------------------------------------------------
// <copyright file="TipoResidencia.cs" company="Bludata Software">
//     Copyright (c) Bludata Software. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CooperDesp.Common
{
    using System;
    using System.ComponentModel;

    public enum TipoResidencia
    {
        Selecione = 0, 
        [Description("Própria")]
        Propria = 1,
        Alugada = 2,
        Parentes = 3,
        [Description("Outros-Especificar")]
        Outros = 4
    }
}