using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM_Model_Library
{
    public interface ILabelCampaignLinkData
    {
        Task<List<LableCampaignLink>> GetLableCampaignLinks();
        Task<List<LableCampaignLink>> GetLableCampaignLinksFromCampaign(string campaignId);
        Task DeleteAllLabelsFromCampaign(string campaignId);
        Task AddLableCampaignLink(LableCampaignLink link);
    }
}