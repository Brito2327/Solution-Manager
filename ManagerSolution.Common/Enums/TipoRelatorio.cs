//-----------------------------------------------------------------------
// <copyright file="TipoRelatorio.cs" company="Bludata Software">
//     Copyright (c) Bludata Software. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CooperDesp.Common
{
    using System.ComponentModel;

    public enum TipoRelatorio
    {
        Nenhum = 0,
        [Description("Relatório de Concessionárias")]
        Concessionarias = 1,
        [Description("Exportação de Tributos Municipais - PRODAM")]
        MultasPRODAM = 2,
        [Description("Relatório de Compensação")]
        Compensacao = 3,
        [Description("Inspeção Veicular - CONTROLAR")]
        Controlar = 4,
        [Description("CRLV")]
        CRLV = 5,
        [Description("Log de Mensageria")]
        LogMensageria = 6,
        [Description("Multas com FUNSET")]
        MultasComFUNSET = 7,
        [Description("Arquivo de Rajada de DARE")]
        DareRajada = 8,
        [Description("Arquivo de Log de DARE")]
        DareLog = 9,
        [Description("LOG Comex")]
        LogComex = 10,
        [Description("FUNDEB")]
        Fundeb = 11,
        [Description("DARF")]
        DARF = 12,
        [Description("GARE")]
        GARE = 13,
        [Description("GARE-CB")]
        GARECB = 14,
        [Description("DARF-Numerado")]
        DARFNumerado = 15,

        //TODO: temporário para permitir utilização dos 2 métodos em paralelo
        LogMensageriaNovo,
    }
}