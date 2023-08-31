using ManagerSolution.Common.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using System.Net;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace ManagerSolution.Common
{
    /// <summary>
    /// Esta classe contém métodos voltados para a utilização do ROL.API
    /// </summary>
    public class Helper
    {
        /// <summary>     
        /// Representação de valor em base 64 (Chave Interna).
        /// </summary>  
        private const string KeyCriptografia = "QnJhc2lsSHVl";

        /// <summary>     
        /// Vetor de bytes utilizados para a criptografia (Chave Externa)     
        /// </summary>     
        private static byte[] bIV = { 0x50, 0x08, 0xF1, 0xDD, 0xDE, 0x3C, 0xF2, 0x18, 0x44, 0x74, 0x19, 0x2C, 0x53, 0x49, 0xAB, 0xBC };

        /// <summary>
        /// Realiza a conversão/desconversão de/para um valor base64.
        /// </summary>
        /// <param name="valor">Valor a ser convertido/desconvertido.</param>
        /// <param name="converterParaBase64">Indica se ir´converter o valor para base64.</param>
        /// <returns>Valor convertido/desconvertido.</returns>
        public static string Base64(string valor, bool converterParaBase64)
        {
            if (converterParaBase64)
            {
                var valorByte = System.Text.Encoding.UTF8.GetBytes(valor);
                return Convert.ToBase64String(valorByte);
            }
            else
            {
                return Encoding.UTF8.GetString(Convert.FromBase64String(valor));
            }
        }


        /// <summary>
        /// Realiza a criptografia de um valor.
        /// </summary>
        /// <param name="valor">Valor a ser criptografado.</param>
        /// <returns>Valor criptografado em base64.</returns>
        public static string Criptografar(string valor)
        {
            try
            {
                if (!string.IsNullOrEmpty(valor))
                {
                    // Cria instancias de vetores de bytes com as chaves
                    byte[] key = Convert.FromBase64String(KeyCriptografia);
                    byte[] value = new UTF8Encoding().GetBytes(valor);

                    // Instancia a classe de criptografia Rijndael
                    using (Rijndael rijndael = new RijndaelManaged())
                    {
                        // Define o tamanho da chave "256 = 8 * 32"
                        // 128 (16 caracteres), 192 (24 caracteres) e 256 (32 caracteres)
                        rijndael.KeySize = 256;

                        // Cria o espaço de memória para guardar o valor criptografado:
                        using (MemoryStream mStream = new MemoryStream())
                        {

                            // Instancia o encriptador
                            using (CryptoStream encryptor = new CryptoStream(
                                mStream,
                                rijndael.CreateEncryptor(key, bIV),
                                CryptoStreamMode.Write))
                            {

                                // Faz a escrita dos dados criptografados no espaço de memória
                                encryptor.Write(value, 0, value.Length);

                                // Despeja toda a memória.
                                encryptor.FlushFinalBlock();
                            }

                            // Pega o vetor de bytes da memória e gera a string criptografada
                            return Convert.ToBase64String(mStream.ToArray());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao criptografar", ex);
            }

            return null;
        }



        ///// <summary>
        ///// Gravar um dado em cache no sistema.
        ///// </summary>
        ///// <param name="chave">Chave de identificação do cache.</param>
        ///// <param name="dado">Dado/Objeto a ser salvo em cache.</param>
        ///// <param name="dataExpiracao">Data de expiração do cache.</param>
        ///// <param name="chaveComplemento">Complemento da chave de identificação do cache.</param>
        //public static void GravarCache(ECache chave, object dado, DateTime dataExpiracao, string chaveComplemento = null)
        //{
        //    if (dataExpiracao < DateTime.UtcNow)
        //    {
        //        throw new Exception("Data de expiração para salvamento de cache está inválida.");
        //    }

        //    try
        //    {
        //        var cache = string.Format("{0}{1}", EnumDescription(chave), chaveComplemento ?? string.Empty);
        //        HttpRuntime.Cache.Insert(cache, dado, null, dataExpiracao, System.Net.Cache.NoSlidingExpiration);
        //    }
        //    catch (Exception)
        //    {
        //        // Não dispara exceção.
        //    }
        //}

        ///// <summary>
        ///// Consulta um dado/objeto salvo em cache.
        ///// </summary>
        ///// <param name="chave">Chave de identificação do cache.</param>
        ///// <param name="chaveComplemento">Complemento da chave de identificação do cache.</param>
        ///// <returns>Objeto salvo em cache.</returns>
        //public static object ConsultarCache(ECache chave, string chaveComplemento = null)
        //{
        //    var cache = string.Format("{0}{1}", EnumDescription(chave), chaveComplemento ?? string.Empty);
        //    var objeto = HttpRuntime.Cache.Get(cache);
        //    return objeto;
        //}

        ///// <summary>
        ///// Remove um dado/objeto salvo em cache.
        ///// </summary>
        ///// <param name="chave">Chave de identificação do cache.</param>
        ///// <param name="chaveComplemento">Complemento da chave de identificação do cache.</param>
        //public static void RemoverCache(ECache chave, string chaveComplemento = null)
        //{
        //    var cache = string.Format("{0}{1}", EnumDescription(chave), chaveComplemento ?? string.Empty);
        //    HttpRuntime.Cache.Remove(cache);
        //}

        /// <summary>
        /// Recupera a descrição de um enumerador.
        /// </summary>
        /// <param name="value">Enumerdor a ser recuperado a descrição.</param>
        /// <returns></returns>
        public static string EnumDescription(Enum value)
        {
            var tipo = value.GetType();
            var campo = tipo.GetField(value.ToString());
            var attributos = campo.GetCustomAttributes(typeof(DescriptionAttribute), false);
            var attributo = attributos.SingleOrDefault() as DescriptionAttribute;

            return attributo == null ? value.ToString() : attributo.Description;
        }

        /// <summary>
        /// Recupera um enumerador apartir de uma descrição.
        /// </summary>
        /// <typeparam name="T">Enum a ser retornado apartir da descrição.</typeparam>
        /// <param name="description">Descrição para recuperar o enumerador.</param>
        /// <returns>Enumerador T o qual contém a descrição informada.</returns>
        public static T DescriptionEnum<T>(string description)
        {
            var type = typeof(T);
            if (!type.IsEnum)
            {
                throw new ArgumentException();
            }

            FieldInfo[] fields = type.GetFields();
            var field = fields.SelectMany(f => f.GetCustomAttributes(typeof(DescriptionAttribute), false), (f, a) => new { Field = f, Att = a })
                        .Where(a => ((DescriptionAttribute)a.Att).Description == description)
                        .SingleOrDefault();

            return field == null ? default(T) : (T)field.Field.GetRawConstantValue();
        }

        /// <summary>
        /// Verifica se uma string é um XML válido.
        /// </summary>
        /// <param name="xml">String com o xml a ser validado.</param>
        /// <param name="saida">Objeto xml criado apartir da string.</param>
        /// <returns>Indica se é válido.</returns>
        public static bool ValidarXML(string xml, out XmlDocument saida)
        {
            saida = new XmlDocument();

            try
            {
                saida.Load(xml);
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Agrupa os paraêmtros SQL server em grupo para não passar do limite de parâmetros que o SQL Server permite.
        /// </summary>
        /// <typeparam name="T">Tipo de parâmetro enviado ao banco</typeparam>
        /// <param name="listaParametros">Lista dos parâmetros a serem separados em grupos.</param>
        /// <param name="quantidadeFixa">Quantidade de parâmetros fixos, que não entrarão no IN</param>
        /// <returns>Lista dos parâmetros agrupados com limite de quantidade.</returns>
        public static List<List<T>> AgruparLimiteParametrosSQL<T>(List<T> listaParametros, int quantidadeFixa = 0)
        {
            var listaAgrupada = new List<List<T>>();

            int quantidadeMaximaParametros = 2000 - quantidadeFixa;

            var quantidadeGrupos = Math.Ceiling(listaParametros.Count > quantidadeMaximaParametros ?
                listaParametros.Count / (double)quantidadeMaximaParametros : 1);

            for (int grupo = 0; grupo < quantidadeGrupos; grupo++)
            {
                listaAgrupada.Add(listaParametros.Skip(grupo * quantidadeMaximaParametros).Take(quantidadeMaximaParametros).ToList());
            }

            return listaAgrupada;
        }

        public static void ProcessarSQLPorGrupos<T>(List<T> listaParametros, Action<Dictionary<string, object>, string> acaoPorGrupo)
        {
            ProcessarSQLPorGrupos(listaParametros, null, acaoPorGrupo);
        }

        /// <summary>
        /// Processa o sql, em grupos
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="listaParametros"></param>
        /// <param name="parametrosFixos">Parâmetros que não estão no 'IN'</param>
        /// <param name="acaoPorGrupo"></param>
        public static void ProcessarSQLPorGrupos<T>(List<T> listaParametros, Dictionary<string, object> parametrosFixos, Action<Dictionary<string, object>, string> acaoPorGrupo)
        {
            parametrosFixos = parametrosFixos ?? new Dictionary<string, object>();
            var parametrosAgrupados = AgruparLimiteParametrosSQL(listaParametros, parametrosFixos.Count);

            foreach (var grupo in parametrosAgrupados)
            {
                var parametros = new Dictionary<string, object>();
                foreach (var fixo in parametrosFixos)
                    parametros.Add(fixo.Key, fixo.Value);
                
                var parametrosQuery = new StringBuilder();

                for (int i = 0; i < grupo.Count; i++)
                {
                    var parametro = string.Format("@item{0}", i);
                    parametrosQuery.AppendFormat("{0}{1}", i == 0 ? string.Empty : ",", parametro);

                    parametros.Add(parametro, grupo[i]);
                }

                acaoPorGrupo(parametros, parametrosQuery.ToString());
            }
        }

        public static string FormataSqlPaginado(string sql, int pagina, int tamanhoPagina)
        {
            if (sql == null)
            {
                throw new Exception("Parâmetro 'sql' está nulo");
            }

            if (!sql.Contains("order by") && !sql.Contains("order"))
            {
                throw new Exception("Parâmetro 'sql' não contém a instrução de order by");
            }

            return string.Format("{0} OFFSET {1} ROWS FETCH NEXT {2} ROWS ONLY ", sql, (pagina - 1) * tamanhoPagina, tamanhoPagina);
        }

        public static string ConverterExceptionTexto(Exception ex)
        {
            var mensagemException = new StringBuilder(ex.ToString());

            while (ex.InnerException != null)
            {
                ex = ex.InnerException;
                mensagemException.AppendLine(ex.ToString());
            }

            return mensagemException.ToString();
        }

        /// <summary>
        /// Valida se um IP é valido no formato IPv4
        /// </summary>
        /// <param name="ip">IPv4</param>
        /// <returns>Indica se é válido</returns>
        public static bool ValidarIP(string ip)
        {
            if (string.IsNullOrWhiteSpace(ip) || ip.Trim().Length > 15)
            {
                return false;
            }

            IPAddress enderecoIP = null;
            return IPAddress.TryParse(ip, out enderecoIP);
        }

        public static string MontarQueryIN(string coluna, List<int> dados)
        {
            return MontarQueryIN(coluna, dados.Cast<int?>().ToList());
        }

        /// <summary>
        /// Monta a query com os valores in
        /// </summary>
        /// <typeparam name="T">Enum</typeparam>
        /// <param name="coluna">Nome da coluna</param>
        /// <param name="dados">A lista de enums</param>
        /// <example> Coluna in (1, 2, 3)</example>
        /// <returns></returns>
        public static string MontarQueryIN<T>(string coluna, IEnumerable<T> dados) where T : Enum
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("Deve ser usada somente com enums!");
            }
            return MontarQueryIN(coluna, dados.Cast<int>().ToList());
        }

        public static string MontarQueryIN(string coluna, List<int?> dados)
        {
            if (dados.Any())
            {
                var sql = new StringBuilder(string.Format(" {0} IN (", coluna));

                dados.ForEach((dado) =>
                {
                    var virgula = dado == dados.First() ? string.Empty : ",";
                    sql.AppendFormat("{0}{1}", virgula, dado.HasValue ? dado.ToString() : "NULL");
                });

                sql.Append(")");

                return sql.ToString();
            }

            return "1 != 1";
        }
    }
}