using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Model_Library
{
    public class DataAccess : IDataAccess
    {
        private readonly IConfiguration _config;

        public string ConnectionStringName { get; set; } = "default";

        public DataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            // Opens a connection to our Database, it does it in a Using statement so that when
            // we're done it will close it properly.
            using (IDbConnection connection = new SqlConnection(_config.GetConnectionString(ConnectionStringName)))
            {
                // Query of Type <T> will map the data comming out into a model of type <T>. It will
                // be a set of those, one per row. Await is added here, to convert it to a list,
                // because you cant convert it to a list while the query is being executed, you have
                // to wait for the query to be done.
                var data = await connection.QueryAsync<T>(sql, parameters);

                // Return is seperated from the query, because it will be easier to debug.
                return data.ToList();
            }
        }

        public async Task SaveData<T>(string sql, T parameters)
        {
            using (IDbConnection connection = new SqlConnection(_config.GetConnectionString(ConnectionStringName)))
            {
                // Executes the SQL string. The Async part of Execute returns a Task.
                await connection.ExecuteAsync(sql, parameters);
            }
        }
    }
}