using System.ComponentModel;

namespace CooperDesp.Common
{
    public enum StatusChequeDevolvido
    {
        [Description("Devolvido com Sucesso")]
        Ok = 0,
        
        [Description("Cheque não Encontrado")]
        NaoEncontrado = 1,
        
        [Description("Erro na Gravação do Cheque")]
        ErroGravacao = 2,

        [Description("Cheque já Consta Como devolvido no Sistema")]
        ChequeJaConstaNoSistema = 3,

        [Description("Cheque devolvido de Desconto de Cheques.")]
        DescontoChequeDevolvido = 4
    }
}
