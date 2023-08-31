using System.ComponentModel;

namespace CooperDesp.Common.Enums
{
    public enum TipoOperacaoCerc : int
    {
        /// <summary>
        /// Criar registro
        /// </summary>
        [Description("C")]
        Criar = 1,

        /// <summary>
        /// Atualizar registro
        /// </summary>
        [Description("A")]
        Atualizar = 2,

        /// <summary>
        /// Inativar
        /// </summary>
        [Description("I")]
        Inativar = 4,

        /// <summary>
        /// Baixar
        /// </summary>
        [Description("B")]
        Baixar = 8,

        /// <summary>
        /// Erro
        /// </summary>
        [Description("Erro")]
        Erro = 16
    }
}
