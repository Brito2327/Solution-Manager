//-----------------------------------------------------------------------
// <copyright file="Bandeiras.cs" company="Bludata Software">
//     Copyright (c) Bludata Software. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CooperDesp.Common
{
    using System;
    using System.ComponentModel;

    public enum Ocupacoes
    {
        Nenhuma = 0,

        Empregado = 1,

        [Description("Sócio, Proprietário, Empresário")]
        SocioProprietarioEmpresario = 2,

        [Description("Vive de renda")]
        Renda = 3,

        [Description("Funcionário Público")]
        FuncionarioPublico = 4,

        [Description("Autônomo")]
        Autonomo = 5,

        [Description("Profissional Liberal")]
        ProfissionalLiberal = 6,

        [Description("Aposentado, Pensionista")]
        AposentadoPensionista = 7,

        [Description("Outro (Dona de Casa, Estudante")]
        Outro = 9
    }
}