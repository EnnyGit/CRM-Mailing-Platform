﻿using MailChimp.Net.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM_Model_Library
{
    public interface ICampaignController
    {
        Task CreateRegularCampaign(string campaignTitle);
        Task<IEnumerable<MailChimp.Net.Models.Campaign>> GetLatestCampaign();
    }
}