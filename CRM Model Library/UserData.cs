using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM_Model_Library
{
    public class UserData : IUserData
    {
        private readonly IDataAccess _db;

        public UserData(IDataAccess db)
        {
            _db = db;
        }

        public Task<List<UserModel>> GetUsers()
        {
            string sql = "SELECT * FROM dbo.Users";

            return _db.LoadData<UserModel, dynamic>(sql, new { });
        }

        public Task InsertUser(UserModel user)
        {
            string sql = @"INSERT INTO dbo.Users(FirstName, LastName, Email, Password)
                           values (@FirstName, @LastName, @Email, @Password);";

            return _db.SaveData(sql, user);
        }
        public Task<List<UserModel>> GetUser(int id)
        {
            string sql = "SELECT * FROM dbo.Contact WHERE UserId = @Id";
            return _db.LoadData<UserModel, dynamic>(sql, new { Id = id });
        }
        public Task<List<UserModel>> FindUser(string email)
        {
            string sql = "SELECT * FROM dbo.Users WHERE Email = @Email";
            return _db.LoadData<UserModel, dynamic>(sql, new { Email = email });

        }
    }
}