using MailChimp.Net.Core;
using MailChimp.Net.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM_Model_Library
{
    public class MailChimpTemplateController : IMailChimpTemplateController
    {
        public async Task<IEnumerable<Template>> GetAllTemplates()
        {
            try
            {
                var templates = await ApiKeyMailChimp.Manager.Templates.GetAllAsync();
                return templates;
            }
            catch (MailChimpException e)
            {
                throw e;
            }
        }

        public async Task<Template> GetTemplateById(int templateId)
        {
            try
            {
                var template = await ApiKeyMailChimp.Manager.Templates.GetAsync(templateId);
                return template;
            }
            catch (MailChimpException e)
            {
                throw e;
            }
        }

        public async Task<Template> GetLatestTemplate()
        {
            IEnumerable<Template> temporaryTemplate;
            var request = new TemplateRequest
            {
                SortByField = TemplateSortField.DateCreated,
                Count = 1,
            };

            try
            {
                temporaryTemplate = await ApiKeyMailChimp.Manager.Templates.GetAllAsync(request);
            }
            catch (MailChimpException e)
            {
                throw e;
            }

            Template template = new Template();
            foreach (var t in temporaryTemplate)
            {
                template = t;
            }
            return template;
        }
    }
}