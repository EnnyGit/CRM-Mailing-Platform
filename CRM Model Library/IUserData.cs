using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM_Model_Library
{
    public interface IUserData
    {
        Task<List<UserModel>> GetUsers();
        Task InsertUser(UserModel user);
        Task<List<UserModel>> GetUser(int id);
        Task<List<UserModel>> FindUser(string email);
    }
}