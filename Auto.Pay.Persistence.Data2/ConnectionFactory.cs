using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using Auto.Pay.Transversal.Common;

namespace Auto.Pay.Persistence.Data
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _connectionFactory;

        public ConnectionFactory(IConfiguration connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        public IDbConnection GetConnection
        {
            get
            {
                SqlConnection sqlConnection = new SqlConnection();
                if (sqlConnection == null) return null;

                sqlConnection.ConnectionString = _connectionFactory.GetConnectionString("PayConnection");
                sqlConnection.Open();
                return sqlConnection;
            }

        }

    }
}
