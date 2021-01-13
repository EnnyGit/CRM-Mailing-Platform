using MailChimp.Net.Core;
using MailChimp.Net.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM_Model_Library
{
    public class MailChimpListController : IMailChimpListController
    {
        public async Task<List> GetDetailOfList(string id)
        {
            try
            {
                var model = await ApiKeyMailChimp.Manager.Lists.GetAsync(id);
                return model;
            }
            catch (MailChimpException e)
            {
                throw e;
            }
        }
    }
}