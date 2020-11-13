using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CRM_Model_Library
{
    public class DataAccess
    {
        /// <summary>
        /// This Method goes to a table and get information out of it.
        /// </summary>
        /// <typeparam name="T">
        /// A generic Type which should be a model object.
        /// </typeparam>
        /// <typeparam name="U">
        /// A generic Type for the parameters input.
        /// </typeparam>
        /// <param name="sql">
        /// This is the statement that says "SELECT * FROM 'Table'"
        /// </param>
        /// <param name="parameters">
        /// A parameter of any type.
        /// </param>
        /// <param name="connectionString">
        /// How we connect to our Database.
        /// </param>
        /// <returns>
        /// Returns a List of Type T models.
        /// </returns>

        public List<T> LoadData<T, U>(string sql, U parameters, string connectionString)
        {
            // Opens a connection to our Database, it does it in a Using statement so that when
            // we're done it will close it properly.
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                // Query of Type <T> will map the data comming out into a model of type <T>. It will be 
                // a set of those, one per row.
                List<T> rows = connection.Query<T>(sql, parameters).ToList();

                // Return is seperated from the query, because it will be easier to debug.
                return rows;
            }
        }

        public void SaveData<T>(string sql, T parameters, string connectionString)
        {
            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                // Executes the SQL string.
                connection.Execute(sql, parameters);
            }
        }
    }
}
