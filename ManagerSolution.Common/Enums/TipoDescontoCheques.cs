//-----------------------------------------------------------------------
// <copyright file="TipoDescontoCheques.cs" company="Bludata Software">
//     Copyright (c) Bludata Software. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CooperDesp.Common
{
    using System;
    using System.ComponentModel;

    public enum TipoDescontoCheques
    {
        Nenhuma = 0,
        CPF = 1,

        [Description("CPF e CNPJ")]
        CPFCNPJ = 2
    }
}