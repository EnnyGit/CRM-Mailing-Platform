using MailChimp.Net.Core;
using MailChimp.Net.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM_Model_Library
{
    public class MailChimpController : IMailChimpController
    {
        public async Task<IEnumerable<Campaign>> SentCampaigns()
        {
            var campaignRequest = new CampaignRequest
            {
                Limit = 999,
                SortField = CampaignSortField.CreateTime,
                SortOrder = CampaignSortOrder.DESC
            };

            try
            {
                var model = await ApiKeyMailChimp.Manager.Campaigns.GetAllAsync(campaignRequest);
                return model;
            }
            catch (MailChimpException e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<List>> GetLists()
        {
            try
            {
                var model = await ApiKeyMailChimp.Manager.Lists.GetAllAsync();
                return model;
            }
            catch (MailChimpException e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<Member>> GetMembers()
        {
            try
            {
                var model = await ApiKeyMailChimp.Manager.Members.GetAllAsync("0756e04de0");
                return model;
            }
            catch (MailChimpException e)
            {
                throw e;
            }
        }
    }
}