using System.ComponentModel;

namespace CooperDesp.Common
{
    public enum TipoOperacao
    {
        Consulta = 0,
        Pagamento = 1,
        Financiamento = 2,
        [Description("Operação de Cartão")]
        Cartao = 3
    }
}