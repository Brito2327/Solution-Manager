using System.ComponentModel;

namespace CooperDesp.Common
{
    public enum TipoLacracao
    {
        [Description("Posto")]
        Detran = 0,
        [Description("Domiciliar")]
        Residencia = 1
    }
}