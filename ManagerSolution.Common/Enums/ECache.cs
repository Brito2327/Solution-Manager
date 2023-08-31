using System.ComponentModel;

namespace ManagerSolution.Common.Enums
{
    /// <summary>
    /// Responsável por manter o nome dos objeto em cache da Aplicação Web.
    /// </summary>
    public enum ECache
    {
        /// <summary>
        /// Método 'Consulta' da classe 'ConsultaPagamento' que se refere ao web service ConsultaPagamento_SVC.
        /// </summary>
        [Description("ConsultaPagamento")]
        ConsultaPagamento = 0,

        /// <summary>
        /// Método 'BuscarBoleto' da classe 'BoletoRendimento' que se refere ao web service BoletoRendimento.
        /// </summary>
        [Description("BoletoRendimentoBuscarBoleto")]
        BoletoRendimentoBuscarBoleto = 1,

        /// <summary>
        /// Método 'BuscaBoletoComSeuNumero' da classe 'BoletoRendimento' que se refere ao web service BoletoRendimento.
        /// </summary>
        [Description("BoletoRendimentoBuscaBoletoComSeuNumero")]
        BoletoRendimentoBuscaBoletoComSeuNumero = 2,

        /// <summary>
        /// Método 'BuscaBoletoComSeuNumero' da classe 'BuscaBoletoBaixado' que se refere ao web service BoletoRendimento.
        /// </summary>
        [Description("BoletoRendimentoBuscaBoletoBaixado")]
        BoletoRendimentoBuscaBoletoBaixado = 3,

        /// <summary>
        /// Método 'BuscaBoletoComSeuNumero' da classe 'ListaBoletosBaixadosPorContaETipo' que se refere ao web service BoletoRendimento.
        /// </summary>
        [Description("BoletoRendimentoListaBoletosBaixadosPorContaETipo")]
        BoletoRendimentoListaBoletosBaixadosPorContaETipo = 4,

        /// <summary>
        /// Método 'BuscaBoletoComSeuNumero' da classe 'ListaBoletosBaixadosPorConta' que se refere ao web service BoletoRendimento.
        /// </summary>
        [Description("BoletoRendimentoListaBoletosBaixadosPorConta")]
        BoletoRendimentoListaBoletosBaixadosPorConta = 5,

        /// <summary>
        /// Método 'BuscaBoletoComSeuNumero' da classe 'ConsultaMunicipios' que se refere ao web service BoletoRendimento.
        /// </summary>
        [Description("BoletoRendimentoConsultaMunicipios")]
        BoletoRendimentoConsultaMunicipios = 6,

        /// <summary>
        /// Método 'Consulta' da classe 'Extrato' que se refere ao web service Extrato.
        /// </summary>
        [Description("ConsultaExtrato")]
        ConsultaExtrato = 7,

        /// <summary>
        /// Lista de AMFDispositivoModel consultados em AMFDispositivoBLL.ObterDispositivoPorDocumento()
        /// </summary>
        [Description("ObterDispositivoPorDocumento")]
        ObterDispositivoPorDocumento = 8,

        /// <summary>
        /// Objeto de AMFClienteModel consultado em AMFClienteBLL.ObterClientePorDocumento()
        /// </summary>
        [Description("ObterClientePorDocumento")]
        ObterClientePorDocumento = 9,

        /// <summary>
        /// Lista de AMFTipoDispositivoFisicoModel consultados em AMFDispositivoBLL.ObterTodosTipoDispositivoFisico()
        /// </summary>
        [Description("ObterTodosTipoDispositivoFisico")]
        ObterTodosTipoDispositivoFisico = 10,


        /// <summary>
        /// Para guardar dados sobre as notícias de bloqueio do sistema
        /// </summary>
        [Description("NoticiaBloqueio")]
        NoticiaBloqueio = 11,
    }
}