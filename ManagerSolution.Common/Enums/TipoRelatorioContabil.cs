using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperDesp.Common
{
    /// <summary>
    /// Tipos de relatórios contábeis.
    /// </summary>
    public enum TipoRelatorioContabil
    {
        Ficha = 0,
        Integracao = 1,
        Cartao = 2,
        IntegracaoParana = 3,
        TrocaCheque = 5,

        /// <summary>
        /// Contábil de Santa Catarina
        /// </summary>
        IntegracaoSantaCatarina = 4,

        /// <summary>
        /// Contábil da TIM
        /// </summary>
        Tim = 6,

        /// <summary>
        /// Contábil da Claro
        /// </summary>
        Claro = 7,
    }
}
