using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Model_Library
{
    public class ContactData : IContactData
    {
        private readonly IDataAccess _db;
        
        public ContactData(IDataAccess db)
        {
            _db = db;
        }

        public Task<List<ContactModel>> GetContacts()
        {
            string sql = "SELECT * FROM dbo.Contact";

            return _db.LoadData<ContactModel, dynamic>(sql, new { });
        }

        public Task InsertContact(ContactModel contact)
        {
            string sql = @"INSERT INTO dbo.client(FirstName, LastName, Email)
                           values (@FirstName, @LastName, @Email);";

            return _db.SaveData(sql, contact);
        }
        public Task<List<ClientModel>> GetClientsOfContact(ContactModel contact) {
            string sql = @"SELECT * FROM dbo.Client cl
                            INNER JOIN dbo.ClientContact cc ON cl.ClientId = cc.ClientId
                            WHERE cc.ContactId = @contact.ContactId";
            return _db.LoadData<ClientModel, dynamic>(sql, new { });

        }
    }
}
