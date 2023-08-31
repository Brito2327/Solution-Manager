using System.ComponentModel;

namespace ManagerSolution.Common
{
    /// <summary>
    /// Contém os possíveis ambientes.
    /// O Description de cada membro, é o valor que deve ser posto no Web.config
    /// </summary>
    public enum Ambiente
    {
        /// <summary>
        /// Ambiente de Produção
        /// </summary>
        [Description("Producao")]
        Producao,

        /// <summary>
        /// Ambiente de Homologação
        /// </summary>
        [Description("Homologacao")]
        Homologacao,

        /// <summary>
        /// Ambiente de Desenvolvimento
        /// </summary>
        [Description("Desenvolvimento")]
        Desenvolvimento
    }
}