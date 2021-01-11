using System;
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

        public Task<List<LabelModel>> GetLables()
        {
            string sql = "SELECT * FROM dbo.Labels";

            return _db.LoadData<LabelModel, dynamic>(sql, new { });
        }

        public Task InsertLabel(LabelModel label)
        {
            string sql = @"INSERT INTO dbo.Lables(Name)
                           values (@Name);";

            return _db.SaveData(sql, label);
        }
    }
}
