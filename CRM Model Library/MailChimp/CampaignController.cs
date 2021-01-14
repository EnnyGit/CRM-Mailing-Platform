using MailChimp.Net.Core;
using MailChimp.Net.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM_Model_Library
{
    public class CampaignController : ICampaignController
    {
        public async Task CreateRegularCampaign(string campaignTitle)
        {
            Campaign campaign = new Campaign
            {
                ContentType = "template",
                Type = CampaignType.Regular,
                Settings = new Setting
                {
                    ReplyTo = "Example@gmail.com",
                    FromName = "Example Name",
                    Title = campaignTitle
                },
                Recipients = new Recipient
                {
                    ListId = "0756e04de0",
                }
            };
            try
            {
                await ApiKeyMailChimp.Manager.Campaigns.AddAsync(campaign);
            }
            catch (MailChimpException e)
            {
                throw e;
            }
        }

        public async Task<IEnumerable<Campaign>> GetLatestCampaign()
        {
            var campaignRequest = new CampaignRequest
            {
                Limit = 1,
                SortField = CampaignSortField.CreateTime,
                SortOrder = CampaignSortOrder.DESC
            };

            try
            {
                var campaign = await ApiKeyMailChimp.Manager.Campaigns.GetAllAsync(campaignRequest);
                return campaign;
            }
            catch (MailChimpException e)
            {
                throw e;
            }
        }

        public async Task UpdateCampaign(Campaign campaign)
        {
            await ApiKeyMailChimp.Manager.Campaigns.UpdateAsync(campaign.Id, campaign);
        }

        public async Task AddListToCampaign(List<ContactModel> contactList, Campaign campaign)
        {
            var segmentMemberList = new List<Member>();
            var allMembers = await ApiKeyMailChimp.Manager.Members.GetAllAsync("0756e04de0");
            foreach (var contact in contactList)
            {
                bool contactExists = false;
                foreach (var member in allMembers)
                {
                    if (contact.EmailAddress == member.EmailAddress)
                    {
                        contactExists = true;
                        segmentMemberList.Add(member);
                    }
                }
                if (!contactExists)
                {
                    var member = new Member
                    {
                        EmailAddress = contact.EmailAddress,
                        StatusIfNew = Status.Subscribed,
                        Status = Status.Subscribed,
                        EmailType = "html",
                        MergeFields = new Dictionary<string, object>
                    {
                        {"FNAME", contact.FirstName},
                        {"LNAME", contact.LastName}
                    }
                    };
                    segmentMemberList.Add(member);
                    await ApiKeyMailChimp.Manager.Members.AddOrUpdateAsync("0756e04de0", member);
                }
            }

            List<string> emailList = new List<string>();
            foreach (var m in segmentMemberList)
            {
                emailList.Add(m.EmailAddress);
            }

            var allSegementsOfList = await ApiKeyMailChimp.Manager.ListSegments.GetAllAsync("0756e04de0");
            bool segmentExists = false;

            foreach (var s in allSegementsOfList)
            {
                if (s.Name == campaign.Settings.Title + campaign.Id)
                {
                    segmentExists = true;
                }
            }
            if (!segmentExists)
            {
                var segment = new Segment
                {
                    Name = campaign.Settings.Title + campaign.Id,
                    EmailAddresses = emailList
                };
                await ApiKeyMailChimp.Manager.ListSegments.AddAsync("0756e04de0", segment);
            }

            await SendCampaign(campaign);
        }

        public async Task SendCampaign(Campaign campaign)
        {
            var allSegementsOfList = await ApiKeyMailChimp.Manager.ListSegments.GetAllAsync("0756e04de0");
            int segmentId = 0;
            foreach (var segment in allSegementsOfList)
            {
                if (segment.Name == campaign.Settings.Title + campaign.Id)
                {
                    segmentId = segment.Id;
                }
            }

            campaign.Recipients.SegmentOptions = new SegmentOptions
            {
                SavedSegmentId = segmentId
            };

            try
            {
                await ApiKeyMailChimp.Manager.Campaigns.AddOrUpdateAsync(campaign);
                await ApiKeyMailChimp.Manager.Campaigns.SendAsync(campaign.Id);
            }
            catch (MailChimpException e)
            {
                throw e;
            }
        }
    }
}