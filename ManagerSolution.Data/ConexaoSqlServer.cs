using CooperDesp.Common;
using ManagerSolution.Data;
using ManagerSolution.Data.DTO;
using System.Data;
using System.Data.SqlClient;

namespace ManagerSolution.RN.Data
{
    public class ConexaoSqlServer
    {
        public ConexaoSqlServer()
        {
            TipoConexao = ETipoConexao.Padrao;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tipoConexao">Conexao especial, default: Padrao</param>
        public ConexaoSqlServer(ETipoConexao tipoConexao) : this()
        {
            TipoConexao = tipoConexao;
        }

        private readonly ETipoConexao TipoConexao = ETipoConexao.Padrao;

        private SqlConnection sqlConnection;
        /*SqlConnection*/
        public SqlConnection SqlConnection
        {
            get
            {
                sqlConnection = new SqlConnection(Parameters.ConnStringPropriedade);
                sqlConnection.Open();
                return sqlConnection;
            }
        }

        private SqlTransaction sqlTransaction = null;
        public SqlTransaction BeginTransaction()
        {
            sqlTransaction = SqlConnection.BeginTransaction();
            return sqlTransaction;
        }

        public void Commit()
        {
            sqlTransaction.Commit();
        }

        public void Rollback()
        {
            sqlTransaction.Rollback();
        }

        public int ExecuteNonQuery(string sql)
        {
            return ExecuteNonQuery(sql, new List<SqlParameter>());
        }
        public int ExecuteNonQuery(string sql, List<SqlParameter> parametros)
        {
            using (var con = SqlConnection)
            {
                using (var command = CriarComando(con, sql, parametros))
                {
                    return command.ExecuteNonQuery();
                }
            }
        }

        public int ExecuteNonQuery(string sql, SqlConnection con)
        {
            return ExecuteNonQuery(sql, new List<SqlParameter>(), con);
        }
        public int ExecuteNonQuery(string sql, List<SqlParameter> parametros, SqlConnection con)
        {
            using (var command = CriarComando(con, sql, parametros))
            {
                return command.ExecuteNonQuery();
            }
        }

        public void ExecuteReader(string sql, Action<SqlDataReader> readerAction)
        {
            ExecuteReader(sql, new List<SqlParameter>(), readerAction);
        }
        public void ExecuteReader(string sql, List<SqlParameter> parametros, Action<SqlDataReader> readerAction)
        {
            using (var con = SqlConnection)
            {
                using (var command = CriarComando(con, sql, parametros))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        readerAction(reader);
                    }
                }
            }
        }

        public void ExecuteReader(string sql, Action<SqlDataReader> readerAction, SqlConnection con)
        {
            ExecuteReader(sql, new List<SqlParameter>(), readerAction, con);
        }
        public void ExecuteReader(string sql, List<SqlParameter> parametros, Action<SqlDataReader> readerAction, SqlConnection con)
        {
            using (var command = CriarComando(con, sql, parametros))
            {
                using (var reader = command.ExecuteReader())
                {
                    readerAction(reader);
                }
            }
        }

        public T ExecuteScalar<T>(string sql)
        {
            return ExecuteScalar<T>(sql, new List<SqlParameter>());
        }
        public T ExecuteScalar<T>(string sql, List<SqlParameter> parametros)
        {
            using (var con = SqlConnection)
            {
                using (var command = CriarComando(con, sql, parametros))
                {
                    return (T)command.ExecuteScalar();
                }
            }
        }

        public T ExecuteScalar<T>(string sql, SqlConnection con)
        {
            return ExecuteScalar<T>(sql, new List<SqlParameter>(), con);
        }
        public T ExecuteScalar<T>(string sql, List<SqlParameter> parametros, SqlConnection con)
        {
            using (var command = CriarComando(con, sql, parametros))
            {
                return (T)command.ExecuteScalar();
            }
        }

        private SqlCommand CriarComando(SqlConnection con, string sql, IEnumerable<SqlParameter> parametros)
        {
            var command = new SqlCommand(sql, con);
            command.CommandTimeout = 0;
            if (sqlTransaction != null)
            {
                command.Transaction = sqlTransaction;
            }

            if (parametros != null)
            {
                foreach (var parametro in parametros)
                {
                    if (parametro.SqlDbType == SqlDbType.NVarChar)
                    {
                        parametro.SqlDbType = SqlDbType.VarChar;
                    }
                    parametro.Value = parametro.Value ?? DBNull.Value;
                    command.Parameters.Add(parametro);
                }
            }

            return command;
        }

        public static ConexaoTransacaoDTO AbrirConexaoTransacao()
        {
            var connection = new ConexaoSqlServer().SqlConnection;
            var transaction = connection.BeginTransaction();

            return new ConexaoTransacaoDTO(connection, transaction);
        }
    }
}
