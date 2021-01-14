using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM_Model_Library
{
    public class LableData : ILableData
    {
        private readonly IDataAccess _db;

        public LableData(IDataAccess db)
        {
            _db = db;
        }

        public Task<List<LableModel>> GetLabels()
        {
            string sql = "SELECT * FROM dbo.Label";

            return _db.LoadData<LableModel, dynamic>(sql, new { });
        }
    }
}