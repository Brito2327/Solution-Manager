//-----------------------------------------------------------------------
// <copyright file="Parameters.cs" company="Bludata Software">
//     Copyright (c) Bludata Software. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace CooperDesp.Common
{
    using System;
    using System.Data.Common;

    /// <summary>
    /// Contém métodos e propriedades estáticos com parâmetros diversos da aplicação
    /// </summary>
    public class Parameters
    {
        /// <summary>
        /// Factory padrão
        /// </summary>
        private static string factory = "";
        public static string FactoryPropriedade
        {
            get
            {
                return factory;
            }
        }


        /// <summary>
        /// ConnectionString padrão
        /// </summary>
        private static string connString = string.Empty;
        public static string ConnStringPropriedade
        {
            get
            {
                return connString;
            }
        }

        /// <summary>
        /// Initializes a new instance of the Parameters class.
        /// Cria um objeto apenas para setar os valores dinâmicos das propriedades estáticas.
        /// Pode ser chamado apenas 1 vez no inicio do programa.
        /// </summary>
        /// <param name="factory">Factory para trabalhar com Banco de Dados. Atualmente é "System.Data.SqlClient"</param>
        /// <param name="paramConexao">String de conexão com Banco de Dados.</param>
        public Parameters(string factory, string paramConexao)
        {
            Parameters.factory = factory;
            Parameters.connString = paramConexao;
        }


        static DbProviderFactory _factory;
        static DbProviderFactory Factory
        {
            get
            {
                if (_factory == null)
                    _factory = DbProviderFactories.GetFactory(Parameters.factory);
                return _factory;
            }
        }

        /// <summary>
        /// Gets um conexão aberta com Banco de Dados.
        /// </summary>
        public static DbConnection Connection
        {
            get
            {
                DbConnection conn = Factory.CreateConnection();
                conn.ConnectionString = connString;

                conn.Open();
                return conn;
            }
        }

        /// <summary>
        /// Obtém uma conexão aberta com Banco de Dados.
        /// </summary>
        public static DbConnection ObterConnection(string conectionString)
        {
            DbConnection conn = Factory.CreateConnection();
            conn.ConnectionString = conectionString;
            conn.Open();
            return conn;
        }

        /// <summary>
        /// Cria um novo parâmetro para trabalhar com sql usando parâmetros.
        /// </summary>
        /// <returns>Novo parâmetro</returns>
        public static DbParameter NewDbParameter()
        {
            return Factory.CreateParameter();
        }

        /// <summary>
        /// Cria um novo parâmetro para trabalhar com sql usando parâmetros. Setanto o Nome e o Valor.
        /// </summary>
        /// <param name="parameterName">Nome do parâmetro</param>
        /// <param name="value">Valor do parâmetro</param>
        /// <returns>Novo parâmetro</returns>
        public static DbParameter NewDbParameter<T>(string parameterName, T value)
        {
            DbParameter p = NewDbParameter();
            p.ParameterName = parameterName;
            p.Value = TipoNulo(value);
            return p;
        }

        private static dynamic TipoNulo<T>(T valor)
        {
            if (valor == null)
            {
                System.Type itemType = typeof(T);

                if (itemType == typeof(int?))
                {
                    return System.Data.SqlTypes.SqlInt32.Null;
                }
                else if (itemType == typeof(long?))
                {
                    return System.Data.SqlTypes.SqlInt64.Null;
                }
                else if (itemType == typeof(bool?))
                {
                    return System.Data.SqlTypes.SqlBoolean.Null;
                }
                else if (itemType == typeof(byte?))
                {
                    return System.Data.SqlTypes.SqlByte.Null;
                }
                else if (itemType == typeof(char?))
                {
                    return System.Data.SqlTypes.SqlChars.Null;
                }
                else if (itemType == typeof(DateTime?))
                {
                    return System.Data.SqlTypes.SqlDateTime.Null;
                }
                else if (itemType == typeof(decimal?))
                {
                    return System.Data.SqlTypes.SqlDecimal.Null;
                }
                else if (itemType == typeof(double?))
                {
                    return System.Data.SqlTypes.SqlDouble.Null;
                }
                else if (itemType == typeof(short?))
                {
                    return System.Data.SqlTypes.SqlInt16.Null;
                }
                else if (itemType == typeof(string))
                {
                    return System.Data.SqlTypes.SqlString.Null;
                }
            }

            return valor;
        }

        /// <summary>
        /// Cria um novo parâmetro para trabalhar com sql usando parâmetros. Setanto Valor.
        /// </summary>
        /// <param name="value">Valor do parâmetro</param>
        /// <returns>Novo parâmetro</returns>
        public static DbParameter NewDbParameter(object value)
        {
            return NewDbParameter(null, value);
        }

        /// <summary>
        /// Código do estabelecimento utilizado na geração dos arquivos de convênios para o Unibanco
        /// </summary>
        /// <returns>Código do Estabelecimento</returns>
        public static string Estabelecimento()
        {
            return "0000076";
        }

        /// <summary>
        /// Código da operadora utilizado na geração dos arquivos de convênios para o Unibanco
        /// </summary>
        /// <returns>Código da Operadora</returns>
        public static string Operadora()
        {
            return "0000004";
        }

        /// <summary>
        /// Código do banco de arrecadação
        /// </summary>
        /// <returns>Código do banco</returns>
        public static int BancoArrecadacao()
        {
            return 633;
        }

        /// <summary>
        /// Agência do banco de arrecadação com dv sem hífem
        /// </summary>
        /// <returns>Agência do banco</returns>
        public static int AgenciaArrecadacao()
        {
            return 19;
        }

        /// <summary>
        /// Agência do banco Rendimento em SC, ainda não está definido
        /// </summary>
        /// <returns></returns>
        public static int AgenciaArrecadacaoSC()
        {
            return 999999;
        }

        /// <summary>
        /// Caixa Postal para Recebimento do Retorno ENVIA/EMBRATEL
        /// </summary>
        /// <returns>Caixa Postal</returns>
        public static string CaixaPostalEnviaEmbratel()
        {
            return "O0055BRENDIMENTO";
        }

        public static bool WAFAtivo { get; set; }

        public static int IPSBRendimento = 68900810;

        public static long CNPJRendimento = 68900810000138;
    }
}