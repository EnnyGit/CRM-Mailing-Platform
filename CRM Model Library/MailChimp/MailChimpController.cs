using System;
using System.Collections.Generic;
using System.Text;
using MailChimp.Net;
using System.Threading.Tasks;
using MailChimp.Net.Core;

namespace CRM_Model_Library
{
    public class MailChimpController : IMailChimpController
    {
        private CampaignController CampaignBuilder = new CampaignController();

        public async Task<IEnumerable<MailChimp.Net.Models.Campaign>> SentCampaigns()
        {
            //await Manager.Campaigns.AddAsync(CampaignBuilder.CreateCampaign());
           
            var options = new CampaignRequest
            {
                SortOrder = CampaignSortOrder.DESC,
                Limit = 10
            };

            try
            {
                var model = await ApiKeyMailChimp.Manager.Campaigns.GetAllAsync();
                return model;
            }
            catch (MailChimpException mce)
            {
                //TODO: Error message "httpStatusCodeResult(HttpStatusCode.BadGateway, mce.Message)"
                var model = await ApiKeyMailChimp.Manager.Campaigns.GetAllAsync(options);
                return model;
            }
            catch (Exception ex)
            {
                //TODO: Error message "httpStatusCodeResult(HttpStatusCode.ServiceUnavailable, ex.Message)"
                var model = await ApiKeyMailChimp.Manager.Campaigns.GetAllAsync(options);
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
