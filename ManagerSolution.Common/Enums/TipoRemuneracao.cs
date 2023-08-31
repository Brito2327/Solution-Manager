using System.ComponentModel;

namespace CooperDesp.Common.Enums
{
    public enum TipoRemuneracao : short
    {
        [Description("Por Guia")]
        PorGuia = 0,
        [Description("Renavam/Dia")]
        RenavamDia = 1,
    }
}
