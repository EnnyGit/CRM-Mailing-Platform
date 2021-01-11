using System;
using System.Collections.Generic;
using System.Text;
using MailChimp.Net;
using System.Threading.Tasks;
using MailChimp.Net.Core;
using MailChimp.Net.Models;

namespace CRM_Model_Library
{
    public class CampaignController : ICampaignController
    {
        public async Task CreateRegularCampaign(string campaignTitle)
        {
            MailChimp.Net.Models.Campaign campaign = new MailChimp.Net.Models.Campaign
            {
                ContentType = "template",
                Type = CampaignType.Regular,
                Settings = new MailChimp.Net.Models.Setting
                {
                    Title = campaignTitle
                }
            };
            await ApiKeyMailChimp.Manager.Campaigns.AddAsync(campaign);
        }

        public async Task<IEnumerable<Campaign>> GetLatestCampaign()
        {
            var campaignRequest = new CampaignRequest
            {
                Limit = 1,
                SortField = CampaignSortField.CreateTime,
                SortOrder = CampaignSortOrder.DESC
            };

            var campaign = await ApiKeyMailChimp.Manager.Campaigns.GetAllAsync(campaignRequest);
            return campaign;
        }

        public async Task UpdateCampaign(Campaign campaign)
        {
            await ApiKeyMailChimp.Manager.Campaigns.UpdateAsync(campaign.Id, campaign);
        }
    }
}



