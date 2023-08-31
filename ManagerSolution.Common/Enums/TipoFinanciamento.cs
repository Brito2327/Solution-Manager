namespace CooperDesp.Common
{
    using System.ComponentModel;
    using System.Runtime.Serialization;

    [DataContract]
    public enum TipoFinanciamento
    {
        [Description("Débitos Veiculares"), EnumMember]
        DebitosVeiculares = 0,
        [Description("Serviços"), EnumMember]
        Servicos = 1,
        [Description("CNH e Débitos Veiculares"), EnumMember]
        CNHDebitosVeiculares = 2,
        [Description("CNH"), EnumMember]
        CNH = 3,
        [Description("Nenhum"), EnumMember]
        Nenhum = 4,
        [Description("Financiamento de Alunos"), EnumMember]
        Alunos = 5,
        [Description("Antecipação de IRPF"), EnumMember]
        AntecipacaoIR = 6,
        [Description("Antecipação de IRPF TED"), EnumMember]
        AntecipacaoIRTED = 7,
    }
}