using System;
using System.Collections.Generic;
using System.Text;
using MailChimp.Net;
using System.Threading.Tasks;
using MailChimp.Net.Core;
using MailChimp.Net.Models;
using CRM_Model_Library;

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
            await ApiKeyMailChimp.Manager.Campaigns.AddAsync(campaign);
        }

        public async Task<IEnumerable<Campaign>> GetLatestCampaign()
        {
            var campaignRequest = new CampaignRequest
            {
                Limit = 1,
                SortField = CampaignSortField.CreateTime,
                SortOrder = CampaignSortOrder.DESC
            };

            var campaign = await ApiKeyMailChimp.Manager.Campaigns.GetAllAsync(campaignRequest);
            return campaign;
        }

        public async Task UpdateCampaign(Campaign campaign)
        {
            await ApiKeyMailChimp.Manager.Campaigns.UpdateAsync(campaign.Id, campaign);
        }

        public async Task AddListToCampaign(List<ContactModel> contactList, Campaign campaign)
        {
            var segmentMemberList = new List<Member>();
            var list = contactList;
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

            //var segment = new Segment
            //{
            //    Name = campaign.Settings.Title + campaign.Id,
            //    EmailAddresses = emailList
            //};

            await SendCampaign2(campaign);

            // 1: Alle contacts krijgen van de Labellinks, deze zet je in een lijst (geen duplicates)
            // 2: Alle contacs van contactLinks toevoegen aan de lijst. (geen duplicates)
            // 3: Maak een nieuwe .net.list aan, deze list ID voeg je toe aan de members.
            // 4: Al deze contacts omzetten in een .net.member.
            // 5: Maak je een .net.List en voeg je alle members toe.
            // 6: voeg je deze list(id) toe aan de campaign.
        }

        // Testing Method
        public async Task SendCampaign(Campaign campaign)
        {
            var member = new Member
            {
                EmailAddress = "0989054@hr.nl",
                StatusIfNew = Status.Subscribed,
                Status = Status.Subscribed,
                EmailType = "html",
                MergeFields = new Dictionary<string, object>
                    {
                        {"FNAME", "Ali"},
                        {"LNAME", "AliTest"}
                    }
            };

            await ApiKeyMailChimp.Manager.Members.AddOrUpdateAsync("0756e04de0", member);

            var segment = new Segment
            {
                EmailAddresses = new List<string>() { "0980471@hr.nl" },
                Name = "CampaignName+ID"
            };



            await ApiKeyMailChimp.Manager.ListSegments.AddAsync("0756e04de0", segment);

            //segemntId 3356039


            var list = await ApiKeyMailChimp.Manager.Lists.GetAsync("0756e04de0");
            await ApiKeyMailChimp.Manager.ListSegments.AddMemberAsync("0756e04de0", "3356039", member);
            var allSegementsOfList = await ApiKeyMailChimp.Manager.ListSegments.GetAllAsync("0756e04de0");
            foreach (var s in allSegementsOfList)
            {
                var segmentId = s.Id;
            }
            var allMembersOfSegment = ApiKeyMailChimp.Manager.ListSegments.GetAllMembersAsync("0756e04de0", "3356039");
            int i;
            i = 10;

            //var testCampaign = new Campaign
            //{
            //    Recipients = new Recipient
            //    {
            //        SegmentOptions = new SegmentOptions
            //        {
            //            SavedSegmentId = "segmentId";
            //        }
            //    }
            //};
        }

        public async Task SendCampaign2(Campaign campaign)
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

            await ApiKeyMailChimp.Manager.Campaigns.AddOrUpdateAsync(campaign);
            var list = await ApiKeyMailChimp.Manager.Lists.GetAsync(campaign.Recipients.ListId);

            await ApiKeyMailChimp.Manager.Campaigns.SendAsync(campaign.Id);
        }
    }
}



