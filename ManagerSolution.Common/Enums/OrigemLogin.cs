//-----------------------------------------------------------------------
// <copyright file="OrigemLogin.cs" company="Bludata Software">
//     Copyright (c) Bludata Software. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CooperDesp.Common
{
    using System;
    using System.ComponentModel;

    public enum OrigemLogin : int
    {
        [Description("Qualquer Origem")]
        QualquerOrigem = 0,

        [Description("Site Rendimentonline")]
        SiteRendimentonline = 1,

        [Description("Site CooperDesp")]
        SiteCooperDesp = 2
    }
}