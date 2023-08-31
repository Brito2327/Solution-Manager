using System.ComponentModel;

namespace CooperDesp.Common.Enums
{
    public enum StatusCheque
    {
        [Description("Cheque permitido para captura/depósito.")]
        Nenhum = 0,
        [Description("Cheque consta como devolvido.")]
        Devolvido = 1,
        [Description("Cheque já foi liberado em outra Operação.")]
        JaConstaDesconto = 2,
        [Description("Cheque já foi Recebido na Troca de Cheques.")]
        JaRecebidoTroca = 3,
        [Description("Cheque já foi utilizado em Financiamento.")]
        JaConstaFinan = 4
    }
}
