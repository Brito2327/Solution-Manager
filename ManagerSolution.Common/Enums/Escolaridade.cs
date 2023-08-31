//-----------------------------------------------------------------------
// <copyright file="Escolaridade.cs" company="Bludata Software">
//     Copyright (c) Bludata Software. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace ManagerSolution.Common
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// Escolaridade
    /// </summary>
    public enum Escolaridade
    {
        /// <summary>
        /// Não informado.
        /// </summary>
        [Description("Selecione")]
        NaoInformado = 0,

        /// <summary>
        /// Primeiro Grau incompleto.
        /// </summary>
        [Description("Primeiro Grau incompleto")]
        PriGrauIncompleto = 1,

        /// <summary>
        /// Primeiro Grau completo.
        /// </summary>
        [Description("Primeiro Grau completo")]
        PriGrauCompleto = 2,

        /// <summary>
        /// Segundo Grau incompleto.
        /// </summary>
        [Description("Segundo Grau incompleto")]
        SegGrauIncompleto = 3,

        /// <summary>
        /// Segundo Grau completo.
        /// </summary>
        [Description("Segundo Grau completo")]
        SegGrauCompleto = 4,

        /// <summary>
        /// Terceiro Grau incompleto.
        /// </summary>
        [Description("Terceiro Grau incompleto")]
        TerGrauIncompleto = 5,

        /// <summary>
        /// Terceiro Grau completo.
        /// </summary>
        [Description("Terceiro Grau completo")]
        TerGrauCompleto = 6,

        /// <summary>
        /// Pós Graduado.
        /// </summary>
        [Description("Pós Graduado")]
        PosGraduado = 7,

        /// <summary>
        /// Mestre.
        /// </summary>
        [Description("Mestre")]
        Mestre = 8,

        /// <summary>
        /// Doutor.
        /// </summary>
        [Description("Doutor")]
        Doutor = 9
    }
}