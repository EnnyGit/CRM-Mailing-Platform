using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM_Model_Library
{
    public class MailChimpTemplateController : IMailChimpTemplateController
    {
        public async Task<IEnumerable<MailChimp.Net.Models.Template>> GetAllTemplates()
        {
            var templates = await ApiKeyMailChimp.Manager.Templates.GetAllAsync();
            return templates;
        }
    }
}
