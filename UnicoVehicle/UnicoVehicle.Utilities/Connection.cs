using System.Configuration;
using System.Data.SqlClient;

namespace UnicoVehicle.Utilities
{
    public class Connection
    {
        private readonly ConnectionProvider _connection;
        private readonly SqlConnection _dbConnection;

        public Connection(ConnectionProvider connection)
        {
            _connection = connection;
            _dbConnection = new SqlConnection(connection.ConnectionString);
        }

        public SqlConnection dbConnection
        {
            get { return _dbConnection; }
        }

        public void OpenConnection()
        {
            if (_dbConnection.State == System.Data.ConnectionState.Closed)
            {
                _dbConnection.Open();
            }
        }

        public void CloseConnection()
        {
            if (_dbConnection.State != System.Data.ConnectionState.Closed)
            {
                _dbConnection.Close();
            }
        }
    }

    public class ConnectionProvider
    {
        public string ConnectionString { get; set; }
    }
}
