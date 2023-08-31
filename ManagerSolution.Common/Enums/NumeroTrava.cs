using System.ComponentModel;

namespace CooperDesp.Common.Enums
{
    public enum NumeroTrava { 
        [Description("Trava 1")]
        TravaOpcional = 1,
        [Description("Trava 2")]
        TravaObrigatoria = 2,
    }
}