using System;
using System.ComponentModel;

namespace CooperDesp.Common
{
    public enum TipoSolicitacao
    {
        [Description("Não")]
        Nenhum = 0,
        [Description("Confirmação de Senha (Utiliza Teclado Virtual)")]
        Senha = 1,
        [Description("Confirmação de Resposta")]
        Resposta = 2
    }
}
