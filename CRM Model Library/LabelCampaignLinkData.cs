using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
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

        public Task<List<LableCampaignLink>> GetLableCampaignLinks()
        {
            string sql = "SELECT * FROM dbo.LabelCampaignLink";

            return _db.LoadData<LableCampaignLink, dynamic>(sql, new { });
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

        //public Task<List<ClientModel>> GetClient(int id)
        //{
        //    string sql = "SELECT * FROM dbo.Client WHERE ClientId = @Id";
        //    return _db.LoadData<ClientModel, dynamic>(sql, new { Id = id });
        //}

        //public Task<List<bool>> IsLabelInCampaign(int labelId, string campaignId)
        //{
        //    string sql = "SELECT EXISTS(SELECT * FROM dbo.LabelCampaignLink WHERE (LabelId = @labelId AND CampaignId = @campaignId))";
        //    return _db.LoadData<bool, dynamic>(sql, new { });
        //}
    }
}
