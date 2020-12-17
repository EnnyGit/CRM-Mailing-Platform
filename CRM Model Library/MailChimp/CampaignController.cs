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
        public MailChimp.Net.Models.Campaign CreateRegularCampaign()
        {
            //Recipient - 
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

        // AddRecipient()
    }
}



