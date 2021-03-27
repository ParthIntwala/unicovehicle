using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using UnicoVehicle.Utilities;

namespace UnicoVehicle.DAL
{
    public class Utils : IUtils
    {
        private readonly Connection _connection;

        public Utils(Connection connection)
        {
            _connection = connection;
        }

        public SqlCommand CommandGenerator(string query)
        {
            _connection.OpenConnection();

            SqlCommand _generatedCommand = new SqlCommand(query, _connection.dbConnection)
            {
                CommandType = CommandType.Text
            };

            return _generatedCommand;
        }
    }
}
