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
            string sql = "SELECT * FROM dbo.Client";

            return _db.LoadData<ClientModel, dynamic>(sql, new { });
        }

        public Task InsertClient(ClientModel client)
        {
            string sql = @"INSERT INTO dbo.Client(ClientName)
                           values (@client.Name);";

            return _db.SaveData(sql, client);
        }
        public Task<List<ContactModel>> GetContactsOfClient(ClientModel client)
        {
            string sql = @"SELECT * FROM dbo.Contact co
                            INNER JOIN dbo.ClientContact cc ON co.ContactId = cc.ContactId
                            WHERE cc.ClientId = @client.ClientId";
            return _db.LoadData<ContactModel, dynamic>(sql, new { });

        }
    }
}
