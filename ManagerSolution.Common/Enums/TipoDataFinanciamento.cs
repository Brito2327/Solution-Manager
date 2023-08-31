using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CooperDesp.Common
{
    public enum TipoDataFinanciamento
    {
        [Description("Operação")]
        Operacao = 0,
        [Description("Liberação")]
        Liberacao = 1,
    }
}
