using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM_Model_Library
{
    // Why? Dependency Injection.
    public interface IDataAccess
    {
        Task<List<T>> LoadData<T, U>(string sql, U parameters, string connectionString);
        Task SaveData<T>(string sql, T parameters, string connectionString);
    }
}