using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM_Model_Library
{
    public interface IContactCampaignLinkData
    {
        Task AddContactCampaignLink(ContactCampaignLink link);
        Task DeleteAllContactsFromCampaign(string campaignId);
        Task<List<ContactCampaignLink>> GetContactCampaignLinks();
        Task<List<ContactCampaignLink>> GetContactCampaignLinksFromCampaign(string campaignId);
    }
}