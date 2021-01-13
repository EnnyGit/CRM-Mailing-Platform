using System;
using System.Collections.Generic;
using System.Text;
using MailChimp.Net;
using System.Threading.Tasks;
using MailChimp.Net.Core;
using MailChimp.Net.Models;

namespace CRM_Model_Library
{
    public class MailChimpController : IMailChimpController
    {
        private CampaignController CampaignBuilder = new CampaignController();

        public async Task<IEnumerable<MailChimp.Net.Models.Campaign>> SentCampaigns()
        {
            //await Manager.Campaigns.AddAsync(CampaignBuilder.CreateCampaign());
           
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
            catch (MailChimpException mce)
            {
                //TODO: Error message "httpStatusCodeResult(HttpStatusCode.BadGateway, mce.Message)"
                var model = await ApiKeyMailChimp.Manager.Campaigns.GetAllAsync(campaignRequest);
                return model;
            }
            catch (Exception ex)
            {
                //TODO: Error message "httpStatusCodeResult(HttpStatusCode.ServiceUnavaiLabel, ex.Message)"
                var model = await ApiKeyMailChimp.Manager.Campaigns.GetAllAsync(campaignRequest);
                return model;
            }
        }

        public async Task<IEnumerable<MailChimp.Net.Models.List>> GetLists()
        {
            var model = await ApiKeyMailChimp.Manager.Lists.GetAllAsync();
            return model;
        }

        public async Task<IEnumerable<MailChimp.Net.Models.Member>> GetMembers()
        {
            var model = await ApiKeyMailChimp.Manager.Members.GetAllAsync("0756e04de0");
            return model;
        }
    }
}
