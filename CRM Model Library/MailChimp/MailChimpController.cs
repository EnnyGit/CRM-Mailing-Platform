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
        private const string ApiKey = "474d98b60a1b310691196071ea85bf44-us7";
        private static readonly MailChimpManager Manager = new MailChimpManager(ApiKey);

        public async Task<IEnumerable<MailChimp.Net.Models.Campaign>> SentCampaigns()
        {
            var options = new CampaignRequest
            {
                Status = CampaignStatus.Sent,
                SortOrder = CampaignSortOrder.DESC,
                Limit = 10
            };

            try
            {
                var model = await Manager.Campaigns.GetAllAsync();
                return model;
            }
            catch (MailChimpException mce)
            {
                //TODO: Error message "httpStatusCodeResult(HttpStatusCode.BadGateway, mce.Message)"
                var model = await Manager.Campaigns.GetAllAsync(options);
                return model;
            }
            catch (Exception ex)
            {
                //TODO: Error message "httpStatusCodeResult(HttpStatusCode.ServiceUnavailable, ex.Message)"
                var model = await Manager.Campaigns.GetAllAsync(options);
                return model;
            }
        }
    }
}
