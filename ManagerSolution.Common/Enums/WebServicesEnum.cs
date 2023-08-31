
using System.ComponentModel;

namespace CooperDesp.Common
{
    public enum WebServicesEnum
    {
        [Description("[Selecione]")]
        Nenhum = 0,
        [Description("Pagamentos de DARF - (ASMX)")]
        DARF_ASMX = 2,
        [Description("F2B - (ASMX)")]
        F2B_ASMX = 4,
        [Description("Consulta Autenticação Digital (Antigo GEVER)")]
        GEVERAutenticacaoDigital_ASMX = 5,
        [Description("Geração e Manipulação de Boletos")]
        BoletoRendimento_SVC = 7,
        [Description("Consultas de Pagamentos (JeW)")]
        ConsultaPagamento_SVC = 8,
        [Description("Pagamentos de Débitos Veiculares de SP")]
        ServPagamentosDebitosVeiculares_SVC = 11,
        [Description("Manipulação de Boletos")]
        TitulosRendimento_SVC = 12,
        [Description("Pagamentos de GAREs")]
        ServPagamentosGare_SVC = 16,
        [Description("Relatório de Arrecadação")]
        RelatorioArrecadacao_SVC = 17,
        [Description("Planos de Cartões de Crédito")]
        PlanosCartoes_SVC = 18,
        [Description("Pagamentos Diversos com Código de Barras")]
        ServPagamentosDiversos_SVC = 20,
        [Description("Consulta de Saldo")]
        Saldos_SVC = 21,
        [Description("Antecipação de Imposto de Renda (Financiamento)")]
        AntecipacaoIR = 22,
        [Description("Pagamentos de Débitos Veiculares de SC")]
        DebitosVeicularesSC = 23,
        [Description("Cálculo de Valor para IPVA e DPVAT de Veículo Zero Km")]
        CalculoValorIPVADPVAT_SVC = 24,
        [Description("Recargas de Telefones")]
        Recargas = 25,
        [Description("Estornos de Pagamentos")]
        Estornos = 26,
        [Description("Pagamentos de DARF")]
        DARF = 27,
        [Description("Pagamentos de Débitos Veiculares de SP Com Cartão de Crédito")]
        PagamentosDebitosVeicularesComCartao = 28,
        [Description("Pagamentos de Serviços Com Cartão de Crédito")]
        PagamentosServicoComCartao = 29,
        [Description("Cadastros de Alunos e Títulos - Instituição de Ensino")]
        InstituicaoDeEnsino = 30,
        [Description("Elef - Operações de Cartão de Crédito")]
        Elef = 100,
        [Description("Pagamentos de Débitos Veiculares de PR")]
        PagamentoPR = 101,
        [Description("Listagem de Postos - IB")]
        Postos = 102,
        [Description("Planos de Financiamentos com Cheques")]
        PlanosFinanciamento = 103,
        [Description("Cadastros de Associados - IB")]
        ServicoDeAssociado = 104,
        [Description("Consulta Recibos (Credinet)")]
        ConsultaPagamento = 105,
        [Description("Gerenciador de Operações")]
        GerenciadorOperacoes = 106,
        [Description("Consulta de Renavam")]
        ServConsultaRenavam = 107,
        [Description("TEDManipulacao")]
        TEDManipulacao = 108,
        [Description("Estorno de Pagamentos")]
        EstornoPagamentos = 109,
        [Description("Consulta Estorno/Recusa de Pagamentos")]
        ServConsultaEstornoRecusa = 110,
        [Description("Consulta de Extrato")]
        Extrato = 113,
        [Description("Extrato Tarifas")]
        ServExtratoTarifasCC = 114,
        [Description("Geração e Manipulação de Boletos Autenticado")]
        BoletoRendimentoAut_SVC = 115,
        [Description("QRCode PIX")]
        QRCodePix = 111
    }
}