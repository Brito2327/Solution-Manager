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
    /// Cont�m m�todos e propriedades est�ticos com par�metros diversos da aplica��o
    /// </summary>
    public class Parameters
    {
        /// <summary>
        /// Factory padr�o
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
        /// ConnectionString padr�o
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
        /// Cria um objeto apenas para setar os valores din�micos das propriedades est�ticas.
        /// Pode ser chamado apenas 1 vez no inicio do programa.
        /// </summary>
        /// <param name="factory">Factory para trabalhar com Banco de Dados. Atualmente � "System.Data.SqlClient"</param>
        /// <param name="paramConexao">String de conex�o com Banco de Dados.</param>
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
        /// Gets um conex�o aberta com Banco de Dados.
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
        /// Obt�m uma conex�o aberta com Banco de Dados.
        /// </summary>
        public static DbConnection ObterConnection(string conectionString)
        {
            DbConnection conn = Factory.CreateConnection();
            conn.ConnectionString = conectionString;
            conn.Open();
            return conn;
        }

        /// <summary>
        /// Cria um novo par�metro para trabalhar com sql usando par�metros.
        /// </summary>
        /// <returns>Novo par�metro</returns>
        public static DbParameter NewDbParameter()
        {
            return Factory.CreateParameter();
        }

        /// <summary>
        /// Cria um novo par�metro para trabalhar com sql usando par�metros. Setanto o Nome e o Valor.
        /// </summary>
        /// <param name="parameterName">Nome do par�metro</param>
        /// <param name="value">Valor do par�metro</param>
        /// <returns>Novo par�metro</returns>
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
        /// Cria um novo par�metro para trabalhar com sql usando par�metros. Setanto Valor.
        /// </summary>
        /// <param name="value">Valor do par�metro</param>
        /// <returns>Novo par�metro</returns>
        public static DbParameter NewDbParameter(object value)
        {
            return NewDbParameter(null, value);
        }

        /// <summary>
        /// C�digo do estabelecimento utilizado na gera��o dos arquivos de conv�nios para o Unibanco
        /// </summary>
        /// <returns>C�digo do Estabelecimento</returns>
        public static string Estabelecimento()
        {
            return "0000076";
        }

        /// <summary>
        /// C�digo da operadora utilizado na gera��o dos arquivos de conv�nios para o Unibanco
        /// </summary>
        /// <returns>C�digo da Operadora</returns>
        public static string Operadora()
        {
            return "0000004";
        }

        /// <summary>
        /// C�digo do banco de arrecada��o
        /// </summary>
        /// <returns>C�digo do banco</returns>
        public static int BancoArrecadacao()
        {
            return 633;
        }

        /// <summary>
        /// Ag�ncia do banco de arrecada��o com dv sem h�fem
        /// </summary>
        /// <returns>Ag�ncia do banco</returns>
        public static int AgenciaArrecadacao()
        {
            return 19;
        }

        /// <summary>
        /// Ag�ncia do banco Rendimento em SC, ainda n�o est� definido
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