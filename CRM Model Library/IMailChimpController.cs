using MailChimp.Net.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM_Model_Library
{
    public interface IMailChimpController
    {
        Task<IEnumerable<Campaign>> SentCampaigns();
    }
}