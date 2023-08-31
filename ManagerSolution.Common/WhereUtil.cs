using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CooperDesp.Common
{
    /// <summary>
    /// Classe auxiliar para geração de sentença SQL que necessita de vários parâmetros na cláusula WHERE
    /// </summary>
    public class WhereUtil
    {
        private StringBuilder strWhere;

        public WhereUtil()
        {
            strWhere = new StringBuilder();
        }

        /// <summary>
        /// Adiciona string à clausula WHERE
        /// </summary>
        /// <param name="str">String que deve ser adicionada, a string NÃO deverá conter WHERE nem AND, eles serão adicionados automaticamente</param>
        public void Append(string str)
        {
            if (!string.IsNullOrEmpty(str.Trim()))
            {
                strWhere.Append(strWhere.Length == 0 ? " where " : " and ");
                strWhere.Append(str);
            }
        }

        /// <summary>
        /// Gera a cláusula WHERE Completa
        /// </summary>
        /// <returns>String com a cláusula WHERE completa</returns>
        public override string ToString()
        {
            return strWhere.ToString();
        }
    }
}
