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
        public async Task<IEnumerable<MailChimp.Net.Models.List>> GetAllLists()
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

        public async Task<MailChimp.Net.Models.List> GetDetailOfList(string id)
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
    }
}
