using System;
using System.Collections.Generic;
using System.Text;
using MailChimp.Net;
using System.Threading.Tasks;
using MailChimp.Net.Core;
using MailChimp.Net.Models;

namespace CRM_Model_Library
{
    public class MailChimpListController : IMailChimpListController
    {
        public async Task<IEnumerable<List>> GetAllLists()
        {
            try
            {
                var model = await ApiKeyMailChimp.Manager.Lists.GetAllAsync();
                return model;
            }
            catch (MailChimpException mce)
            {
                var model = await ApiKeyMailChimp.Manager.Lists.GetAllAsync();
                return model;
            }
            catch (Exception ex)
            {
                var model = await ApiKeyMailChimp.Manager.Lists.GetAllAsync();
                return model;
            }
        }

        public async Task<List> GetDetailOfList(string id)
        {
            try
            {
                var model = await ApiKeyMailChimp.Manager.Lists.GetAsync(id);
                return model;
            }
            catch (MailChimpException mce)
            {
                var model = await ApiKeyMailChimp.Manager.Lists.GetAsync(id);
                return model;
            }
            catch (Exception ex)
            {
                var model = await ApiKeyMailChimp.Manager.Lists.GetAsync(id);
                return model;
            }
        }

        public async Task AddMemberToList()
        {
            //MailChimp.Net.Models.Member member1 = new MailChimp.Net.Models.Member
            //{
            //    EmailAddress = "FakeEmail1@gmail.com",
            //    ListId = "0756e04de0",
            //    Status = MailChimp.Net.Models.Status.Subscribed
            //};
            //member1.MergeFields.Add("FNAME", "Jan");
            //member1.MergeFields.Add("LNAME", "DeMan");

            //MailChimp.Net.Models.Member member2 = new MailChimp.Net.Models.Member
            //{
            //    EmailAddress = "FakeEmail2@gmail.com",
            //    ListId = "0756e04de0",
            //    Status = MailChimp.Net.Models.Status.Subscribed
            //};
            //member2.MergeFields.Add("FNAME", "Ban");
            //member2.MergeFields.Add("LNAME", "AeMan");

            //MailChimp.Net.Models.Member member3 = new MailChimp.Net.Models.Member
            //{
            //    EmailAddress = "FakeEmail3@gmail.com",
            //    ListId = "0756e04de0",
            //    Status = MailChimp.Net.Models.Status.Subscribed
            //};
            //member3.MergeFields.Add("FNAME", "Tan");
            //member3.MergeFields.Add("LNAME", "KeMan");

            var list = await ApiKeyMailChimp.Manager.Lists.GetAsync("0756e04de0");
            int i;
            var membersList = await ApiKeyMailChimp.Manager.Members.GetAllAsync("0756e04de0");
            i = 10;
        }

        public async Task AddMemberToList2()
        {
            try
            {
                var member = new Member
                {
                    EmailAddress = "0980471@hr.nl",
                    StatusIfNew = Status.Subscribed,
                    Status = Status.Subscribed,
                    EmailType = "html",
                    MergeFields = new Dictionary<string, object>
                    {
                        {"FNAME", "Enny"},
                        {"LNAME", "EnnyLastName"}
                    }
                };
                await ApiKeyMailChimp.Manager.Members.AddOrUpdateAsync("0756e04de0", member);
            }
            catch (MailChimpException e)
            {
                throw e;
            }
        }
    }
}
