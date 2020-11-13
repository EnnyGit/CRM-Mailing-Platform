using DataAccessLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Model_Library
{
    class ClientData : IClientData
    {
        private readonly ISqlDataAccess _db;

        // Now this class has access to IsqlDataAccess.
        public ClientData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<ClientModel>> GetClients()
        {
            string sql = "select * from dbo.Client";

            return _db.LoadData<ClientModel, dynamic>(sql, new { });
        }

        public Task InsertClient(ClientModel person)
        {
            string sql = @"insert into dbo.People (FirstName, Lastname, EmailAddress)
                            values (@FirstName, @LastName, @EmailAddress);";

            return _db.SaveData(sql, person);
        }
    }
}
