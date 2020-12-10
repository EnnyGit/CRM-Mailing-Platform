using System;
using System.Collections.Generic;
using System.Text;
using MailChimp.Net;
using System.Threading.Tasks;
using MailChimp.Net.Core;

namespace CRM_Model_Library
{
    public class CampaignController : ICampaignController
    {
        private const string ApiKey = "474d98b60a1b310691196071ea85bf44-us7";
        private static readonly MailChimpManager Manager = new MailChimpManager(ApiKey);

        public MailChimp.Net.Models.Campaign CreateCampaign()
        {
            //Recipient
            //Create_time ( moeten wij Automatisch aanmaken )
            // Id (automatisch?)
            //settings.title = camp[aign Title
            //campaign.Recipients

            MailChimp.Net.Models.Campaign campaign = new MailChimp.Net.Models.Campaign
            {
                ContentType = "template",
                Type = CampaignType.Regular,
                Settings = new MailChimp.Net.Models.Setting
                {
                    Title = "HeleMooieNaam2"
                }
            };
            return campaign;
        }
    }
}



