//-----------------------------------------------------------------------
// <copyright file="Bandeiras.cs" company="Bludata Software">
//     Copyright (c) Bludata Software. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CooperDesp.Common
{
    using System.ComponentModel;

    public enum Bandeiras
    {
        Nenhuma = 0,

        VISA = 1,

        MASTERCARD = 2,

        [Description("AMERICAN EXPRESS")]
        AMERICANEXPRESS = 3,

        [Description("DINERS CLUB")]
        DINERSCLUB = 4,

        HIPERCARD = 5,

        AURA = 6,

        [Description("GOOD CARD")]
        GOODCARD = 7,

        CREDICARD = 8,

        OUTRO
    }
}