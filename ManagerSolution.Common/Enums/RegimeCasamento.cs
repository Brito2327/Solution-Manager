//-----------------------------------------------------------------------
// <copyright file="RegimeCasamento.cs" company="Bludata Software">
//     Copyright (c) Bludata Software. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CooperDesp.Common
{
    using System;
    using System.ComponentModel;

    public enum RegimeCasamento
    {
        Nenhuma = 0,

        [Description("Comunhão Universal")]
        Universal = 1,

        [Description("Comunhão Parcial")]
        Parcial = 2,

        [Description("Participação Final nos Aqüestos")]
        ParticipacaoFinal = 3,

        [Description("Separação de Bens")]
        Separacao = 4
    }
}