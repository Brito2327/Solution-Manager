//-----------------------------------------------------------------------
// <copyright file="TipoFichaContabil.cs" company="Bludata Software">
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
    public enum TipoFichaContabil
    {
        /// <summary>
        /// IPVA Estado
        /// </summary>
        IPVA = 0,

        /// <summary>
        /// IPVA Municipios
        /// </summary>
        Licenciamento = 1,

        /// <summary>
        /// IPVA Municipios
        /// </summary>
        Transferencia = 2,

        /// <summary>
        /// 1º Emplacamento
        /// </summary>
        PrimeiroEmplacamento = 3,

        /// <summary>
        /// DPVAT
        /// </summary>
        DPVAT = 4,

        /// <summary>
        /// Multas
        /// </summary>
        Multas = 5,

        /// <summary>
        /// Multas Municipios
        /// </summary>
        MultasMunicipios = 6,

        /// <summary>
        /// GARE DR
        /// </summary>
        GAREDR = 7,

        /// <summary>
        /// GARE ICMS
        /// </summary>
        GAREICMS = 8,

        /// <summary>
        /// GARE ITCMD
        /// </summary>
        GAREITCMD = 9,

        /// <summary>
        /// FUNSET
        /// </summary>
        FUNSET = 10,

        /// <summary>
        /// Correpondentes
        /// </summary>
        Correpondentes = 11,

        RENAINF = 12,
        RECARGAS = 13,
        DAMSP = 14,
        CETESB = 15,
        Total_1_a_11_e_15 = 16,
        Contas_Consumo = 17,
        Recarga = 18,
        CONTROLAR = 19,
        CartaoTransacao = 20,
        CartaoApropriacao = 21,
        PagamentoDespachante = 22,
        CartaoSemAntecipacaoOperacao = 23,
        CartaoSemAntecipacaoRecebimentoParcela = 24,
        CartaoServicoComAntecipacao = 25,


        //Contabil do Paraná
        DETRANPR = 26,
        SEFAPR_IPVA = 27,
        SEFAPR_ICMS = 28,
        SEFAPR_ITCMD = 29,
        SEFAPR_TAXAS = 30,
        SEFAPR_OutrasReceitas = 31,
        Total_16_a_21 = 32,

        //Troca de cheque
        TrocaCheque_Total_1_a_3 = 36,
        TrocaCheque_Itau = 37,
        TrocaCheque_Bancoob = 38,
        TrocaCheque_FichaCompensacao = 39,

        //DPVATPR = 32,
        //DPVATPR_TARIFA = 33,
        //DPVATPR_SEGLIDER = 34,
        //DPVATPR_DENATRAN = 35,
        //DPVATPR_FNS = 36,

        /// <summary>
        /// GNRE de Santa Catarina
        /// </summary>
        GNRESC = 33,

        /// <summary>
        /// DARE de Santa Catarina
        /// </summary>
        DARESC = 34,

        /// <summary>
        /// Total(GNRE+DARE) de Santa Catarina
        /// </summary>
        TotalSC = 35,

        //TIM
        TotalTim = 44,

        //Claro
        TotalClaro = 88,

        /// <summary>
        /// Nenhum
        /// </summary>
        Nenhum = 99,
    }
}