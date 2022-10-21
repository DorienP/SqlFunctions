using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlFunctions.Data.Entities;
using Microsoft.Data.SqlClient;

namespace SqlFunctions.Context
{
    public class ClientContext
    {
        private string connectionString;
        public ClientContext()
        {
            connectionString = Environment.GetEnvironmentVariable("SqlConnection", EnvironmentVariableTarget.Process);
        }
        public IDbConnection CreateConnection() => new SqlConnection(connectionString);

    }
}
