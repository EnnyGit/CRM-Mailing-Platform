﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Model_Library
{
    public class LabelData : ILabelData
    {
        private readonly IDataAccess _db;

        public LabelData(IDataAccess db)
        {
            _db = db;
        }

        public Task<List<LabelModel>> GetLabels()
        {
            string sql = @"SELECT * FROM dbo.Label";

            return _db.LoadData<LabelModel, dynamic>(sql, new { });
        }

        public Task InsertLabel(LabelModel label)
        {
            string sql = @"INSERT INTO dbo.Label(LabelName)
                           values (@LabelName);";

            return _db.SaveData(sql, label);
        }
        public Task<List<LabelModel>> GetLabel(int id)
        {
            string sql = @"SELECT * FROM dbo.Label WHERE LabelId = @Id";
            return _db.LoadData<LabelModel, dynamic>(sql, new { Id = id });
        }
        public Task<List<ContactModel>> GetContactsWithLabel(int labelId)
        {
            string sql = @"SELECT * FROM dbo.Contact co INNER JOIN dbo.ContactLabel cl ON co.ContactId = cl.ContactId WHERE cl.LabelId = @Id";
            return _db.LoadData<ContactModel, dynamic>(sql, new { Id = labelId });
        }
        public Task InsertLink(int labelId, int contactId)
        {
            string sql = "INSERT INTO dbo.ContactLabel (ContactId,LabelId) VALUES (@coId, @laId)";
            return _db.SaveData(sql, new { coId = contactId, laId = labelId });
        }
        public Task DeleteLink(int labelId, int contactId)
        {
            string sql = "DELETE FROM dbo.ContactLabel WHERE ContactId = @coId AND LabelId = @laId";
            return _db.SaveData(sql, new { coId = contactId, laId = labelId });
        }
    }
}
