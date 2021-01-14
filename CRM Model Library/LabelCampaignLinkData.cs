using Dapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM_Model_Library
{
    public class LabelCampaignLinkData : ILabelCampaignLinkData
    {
        private readonly IDataAccess _db;

        public LabelCampaignLinkData(IDataAccess db)
        {
            _db = db;
        }

        public Task<List<LableCampaignLink>> GetLableCampaignLinksFromCampaign(string campaignId)
        {
            var dictionary = new Dictionary<string, object>
            {
                { "@Id", campaignId }
            };
            var parameters = new DynamicParameters(dictionary);
            //string sql = "SELECT * FROM dbo.LabelCampaignLink WHERE CampaignId = '@Id'";
            string sql = "SELECT * FROM dbo.LabelCampaignLink WHERE campaignId = @Id";
            return _db.LoadData<LableCampaignLink, dynamic>(sql, parameters);
        }

        public Task DeleteAllLabelsFromCampaign(string campaignId)
        {
            var dictionary = new Dictionary<string, object>
            {
                { "@Id", campaignId }
            };
            var parameters = new DynamicParameters(dictionary);
            string sql = "DELETE FROM dbo.LabelCampaignLink WHERE CampaignId = @Id";

            return _db.SaveData(sql, parameters);
        }

        public Task AddLableCampaignLink(LableCampaignLink link)
        {
            string sql = @"INSERT INTO dbo.LabelCampaignLink(LabelId, CampaignId)
                           VALUES (@LabelId, @CampaignId);";

            return _db.SaveData(sql, link);
        }
    }
}