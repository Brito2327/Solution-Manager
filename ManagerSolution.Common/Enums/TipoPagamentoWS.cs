namespace CooperDesp.Common
{
    using System.ComponentModel;

    public enum TipoPagamentoWS
    {
        [Description("Pagamento de Títulos Diversos")]
        Boleto = 0,
        [Description("Pagamento de Convênios")]
        Convenio = 1,
        [Description("Pagamento de Débitos Veiculares")]
        DebitosVeiculares = 2,
        [Description("Pagamento de DARFs")]
        DARF = 3,
        [Description("Geração/Manipulação de Boletos")]
        GeracaoBoleto = 4,
        [Description("Consulta de Pagamentos")]
        ConsultaPagamento = 5,
        [Description("Planos de Financiamento")]
        PlanosFinanciamento = 8,
    }
}