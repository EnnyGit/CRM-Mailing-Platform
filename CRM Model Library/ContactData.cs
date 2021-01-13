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
            string sql = @"INSERT INTO dbo.Contact(FirstName, LastName, EmailAddress)
                           values (@FirstName, @LastName, @EmailAddress);";

            return _db.SaveData(sql, contact);
        }

        public Task<List<ClientModel>> GetClientsOfContact(int contactId) {
            string sql = @"SELECT * FROM dbo.Client cl INNER JOIN dbo.ClientContact cc ON cl.ClientId = cc.ClientId WHERE cc.ContactId = @Id";
            return _db.LoadData<ClientModel, dynamic>(sql, new { Id = contactId });

        }
        public Task<List<ContactModel>> GetSelectContacts(int start, int rows)
        {
            string sql = "SELECT * FROM dbo.Contact ORDER BY ContactId OFFSET @start ROWS FETCH NEXT @rows ROWS ONLY";
            return _db.LoadData<ContactModel, dynamic>(sql, new { });
        }
        public Task<List<ContactModel>> GetContact(int id)
        {
            string sql = "SELECT * FROM dbo.Contact WHERE ContactId = @Id";
            return _db.LoadData<ContactModel, dynamic>(sql, new { Id = id });
        }

        public Task<List<ContactModel>> GetListOfContactsByLabelId(int labelId)
        {
            string sql = "SELECT * FROM dbo.ContactLabelLink WHERE LabelId = @id";
            return _db.LoadData<ContactModel, dynamic>(sql, new { Id = labelId });
        }

        public Task InsertLink(int contactId, int clientId)
        {
            string sql = "INSERT INTO dbo.ClientContact (ContactId,ClientId) VALUES (@coId, @clId)";
            return _db.SaveData(sql, new {coId = contactId,clId = clientId });
        }
        public Task DeleteLink(int contactId,int clientId)
        {
            string sql = "DELETE FROM dbo.ClientContact WHERE ContactId = @coId AND ClientId = @clid";
            return _db.SaveData(sql, new { coId = contactId, clId = clientId });
        }
    }
}
