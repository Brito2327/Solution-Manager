using System.ComponentModel;

namespace CooperDesp
{
    /// <summary>
    /// Este enum é utilizado no autoriza pagamento para verificar se tem trava
    /// por tipo.
    /// </summary>
    public enum TipoPagamento
    {
        Nenhum = 0,
        GARE_CNH = 1,
        GARE_DR = 2,
        GARE_ICMS = 3,
        GARE_IPVA = 4,
        GARE_ITCMD = 5,
        GARE_CodigoBarras = 6,
        DAMSP = 7,
        OutraViaCRLV = 8,
        Veic_Transferencia = 9,
        Veic_Licenciamento = 10,
        Veic_TodosDebitos = 11,
        Veic_IPVA = 12,
        Veic_2vLicenciamento = 13,
        Veic_2vTransferencia = 14,
        Veic_1oRegistro = 15,
        Veic_DPVAT = 16,
        Veic_MultasTransito = 17,

        [Description("Boletos")]
        Dive_Compensacao = 18,
        Dive_Convenio = 19,
        Dive_Recarga = 20,
        Dive_Serasa = 21,
        DARF = 22,
        Veic_InspecaoVeicular = 23,
        DARE = 24,
        Dive_CompensacaoRendimento = 25,
        Veic_SC = 26,
        TED = 98,
        Recibo = 99,

        ReciboCBDETRANPR = 100,
        ReciboOnlineDETRANPR = 101,
        ReciboCBSEFAPR = 102,
        ReciboOnlineSEFAPR = 103,
        ReciboTabelaC = 104,

        ConsultaVeicularBNDV = 105,
        AgillitasCartaoPrePago = 106,

        CompraSeloPR = 107,

        /// <summary>
        /// Recibo débitos de SC Online (DetranNet SC)
        /// </summary>
        ReciboSCOnline = 108,

        Pix = 109,
        [Description("PIX Saque/Troco")]
        PixSaqueTroco = 1090,
        DevolucaoPix = 110,

        /// <summary>
        /// Utilizado somente na lista restrita
        /// </summary>
        OperacaoCartao=111,
    }
}