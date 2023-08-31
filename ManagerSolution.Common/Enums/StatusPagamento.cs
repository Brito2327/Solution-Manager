using System.ComponentModel;

namespace CooperDesp.Common.Enums
{
    public enum StatusPagamento
    {
        [Description("Pagamento Relializado com sucesso.")]
        Pago = 1,
        [Description("Pagamento Baixado com sucesso.")]
        Baixado = 2,
        [Description("Pagamento Estornado.")]
        Estornado = 3,
        [Description("Erro no Pagamento.")]
        Erro = 4
      
    }
}
