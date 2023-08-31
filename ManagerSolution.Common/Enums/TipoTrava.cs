using System.ComponentModel;

namespace CooperDesp.Common.Enums
{
    public enum TipoTrava
    {
        [Description("Liberação de Operações de Cartões")]
        LiberacaoOperacaoCartao = 1,
        [Description("Liberação de Financiamentos")]
        LiberacaoFinanciamento = 2,

        [Description("Pagamentos Diversos Compensação")]
        PagamentoDiversoCompensacao = 18,
        [Description("Pagamentos Diversos Convênios")]
        PagamentoDiversoConvenio = 19,

        /// <summary>
        /// Trava para débitos de Santa catarina (pagamentos e processamento de pagamento na DetranNet)
        /// </summary>
        [Description("Débitos Santa Catarina")]
        DebitosSantaCatarina = 20,
        [Description("Pagamentos Diversos Convênios - Bancoob")]
        PagamentoDiversoConvenioBancoob = 756,
        [Description("Pagamentos Diversos Convênios - ITAÚ")]
        PagamentoDiversoConvenioItau = 341,
        [Description("Pagamentos Diversos Convênios - TIM")]
        PagamentoDiversoConvenioTIM = 1500,
        [Description("Pagamentos Diversos Convênios - Receita")]
        PagamentoDiversoConvenioReceita = 1550,

        [Description("Pagamentos Diversos Convênios - Claro")]
        PagamentoDiversoConvenioClaro = 1700,

        [Description("Envio de Cheques pelo Celular")]
        CapturaChequeMobile = 1750,

        [Description("Geração Arquivo de Cancelamento Função")]
        GeracaoArquivoCancelamentoFuncao = 1751,
    }
}
