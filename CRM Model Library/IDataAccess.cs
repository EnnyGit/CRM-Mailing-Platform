using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM_Model_Library
{
    public interface IDataAccess
    {
        Task<List<T>> LoadData<T, U>(string sql, U parameters);

        Task SaveData<T>(string sql, T parameters);
    }
}