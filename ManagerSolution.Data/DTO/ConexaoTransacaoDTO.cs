using System;
using System.Data;

namespace ManagerSolution.Data.DTO
{
    public class ConexaoTransacaoDTO : IDisposable
    {
        public ConexaoTransacaoDTO(IDbConnection connection, IDbTransaction transaction)
        {
            Connection = connection;
            Transaction = transaction;
        }

        public IDbConnection Connection { get; set; }
        public IDbTransaction Transaction { get; set; }

        public void Dispose()
        {
            if (Connection != null)
            {
                Connection.Dispose();
            }

            if (Transaction != null)
            {
                Transaction.Dispose();
            }
        }
    }
}
