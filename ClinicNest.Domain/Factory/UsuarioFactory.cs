using ClinicNest.Domain.Entities;
using ClinicNest.Domain.SqlServer;

namespace ClinicNest.Domain.Factory
{
    public class UsuarioFactory
    {
        public void Create(Usuario usuario)
        {
            var sql = "INSERT INTO USUARIO (column1, column2, column3, ...) VALUES (value1, value2, value3, ...);";


            try
			{
                var con = new ConnctionSqlServer();
                
               

            }
			catch (Exception)
			{

				throw;
			}

        }
    }
}
