using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperDesp.Common
{
    public enum OperacoesTela
    {
        Inicio,
        MostraListasLote,
        MostraItensLote,
        MostraRecibos,
        MostraAprovacao
    }

    public enum OperacoesItensTela
    {
        EmDigitacao,
        AguardandoConferencia,
        AguardandoAprovacao
    }

    public enum OperacoesCancelamento
    {
        CancelamentoLoteAguardandoConferencia,
        CancelamentoItemAguardandoConferencia,
        CancelamentoLoteAguardandoAprovacao,
        CancelamentoItemAguardandoAprovacao,
    }
}
