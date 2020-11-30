using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Model_Library
{
    public class ClientData : IClientData
    {
        private readonly IDataAccess _db;

        public ClientData(IDataAccess db)
        {
            _db = db;
        }

        public Task<List<ClientModel>> GetClients()
        {
            string sql = "SELECT * FROM dbo.client";

            return _db.LoadData<ClientModel, dynamic>(sql, new { });
        }

        public Task InsertClient(ClientModel client)
        {
            string sql = @"INSERT INTO dbo.client(FirstName, LastName, Email)
                           values (@FirstName, @LastName, @Email);";

            return _db.SaveData(sql, client);
        }
    }
}
