using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperDesp.Common
{
    public enum TipoDocumentoTrocaCheque : int
    {
        Convenio = 1,
        Boleto = 2,
        GareCB = 3,
        DAMSP = 4,
        GAREDR = 5,
        GAREIPVA = 6,
        Debito = 7,
        CNH = 8,
        ReciboTabelaC = 9,
        Parana = 10,

        /// <summary>
        /// Pagamento online de débitos sc (DetranNet SC)
        /// </summary>
        DebitoSC = 11,
    }
}
