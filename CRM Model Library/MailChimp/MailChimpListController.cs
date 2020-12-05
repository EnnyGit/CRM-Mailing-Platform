using System;
using System.Collections.Generic;
using System.Text;
using MailChimp.Net;
using System.Threading.Tasks;
using MailChimp.Net.Core;

namespace CRM_Model_Library
{
    class MailChimpListController
    {
        private const string ApiKey = "474d98b60a1b310691196071ea85bf44-us7";
        private static readonly MailChimpManager Manager = new MailChimpManager(ApiKey);

        public async Task<IEnumerable<MailChimp.Net.Models.List>> Index()
        {
            try
            {
                var model = await Manager.Lists.GetAllAsync();
                return model;
            }
            catch (MailChimpException mce)
            {
                var model = await Manager.Lists.GetAllAsync();
                return model;
            }
            catch (Exception ex)
            {
                var model = await Manager.Lists.GetAllAsync();
                return model;
            }

        }

        public async Task<MailChimp.Net.Models.List> Detail(string id)
        {
            try
            {
                var model = await Manager.Lists.GetAsync(id);
                return model;
            }
            catch (MailChimpException mce)
            {
                var model = await Manager.Lists.GetAsync(id);
                return model;
            }
            catch (Exception ex)
            {
                var model = await Manager.Lists.GetAsync(id);
                return model;
            }
        }

    }
}
