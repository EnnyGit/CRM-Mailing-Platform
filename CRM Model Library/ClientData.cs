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
            string sql = @"INSERT INTO dbo.Client(Name)
                           values (@Name);";

            return _db.SaveData(sql, client);
        }
        public Task<List<ContactModel>> GetContactsOfClient(int clientId)
        {
            string sql = @"SELECT * FROM dbo.Contact co INNER JOIN dbo.ClientContact cc ON co.ContactId = cc.ContactId WHERE cc.ClientId = @Id";
            return _db.LoadData<ContactModel, dynamic>(sql, new {Id= clientId });

        }
        public Task InsertLink(int clientId,int contactId)
        {
            string sql = "INSERT INTO dbo.ClientContact (ContactId,ClientId) VALUES (@coId, @clId)";
            return _db.SaveData(sql, new { coId = contactId, clId = clientId });
        }
        public Task<List<ClientModel>> GetClient(int id)
        {
            string sql = "SELECT * FROM dbo.Client WHERE ClientId = @Id";
            return _db.LoadData<ClientModel, dynamic>(sql, new { Id = id });
        }
        public Task DeleteLink(int clientId, int contactId)
        {
            string sql = "DELETE FROM dbo.ClientContact WHERE ContactId = @coId AND ClientId = @clid";
            return _db.SaveData(sql, new { coId = contactId, clId = clientId });
        }
    }
}
