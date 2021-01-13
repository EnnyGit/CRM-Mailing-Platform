using Dapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Model_Library
{
    public class ContactCampaignLinkData : IContactCampaignLinkData
    {
        private readonly IDataAccess _db;

        public ContactCampaignLinkData(IDataAccess db)
        {
            _db = db;
        }

        public Task<List<ContactCampaignLink>> GetContactCampaignLinks()
        {
            string sql = "SELECT * FROM dbo.ContactCampaignLink";

            return _db.LoadData<ContactCampaignLink, dynamic>(sql, new { });
        }

        public Task<List<ContactCampaignLink>> GetContactCampaignLinksFromCampaign(string campaignId)
        {
            var dictionary = new Dictionary<string, object>
            {
                { "@Id", campaignId }
            };
            var parameters = new DynamicParameters(dictionary);
            string sql = "SELECT * FROM dbo.ContactCampaignLink WHERE campaignId = @Id";
            return _db.LoadData<ContactCampaignLink, dynamic>(sql, parameters);
        }

        public Task DeleteAllContactsFromCampaign(string campaignId)
        {
            var dictionary = new Dictionary<string, object>
            {
                { "@Id", campaignId }
            };
            var parameters = new DynamicParameters(dictionary);
            string sql = "DELETE FROM dbo.ContactCampaignLink WHERE CampaignId = @Id";

            return _db.SaveData(sql, parameters);
        }

        public Task AddContactCampaignLink(ContactCampaignLink link)
        {
            string sql = @"INSERT INTO dbo.ContactCampaignLink(ContactId, CampaignId)
                           VALUES (@ContactId, @CampaignId);";

            return _db.SaveData(sql, link);
        }
    }
}
