using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MailChimp.Net.Core;
using MailChimp.Net.Models;

namespace CRM_Model_Library
{
    public class MailChimpTemplateController : IMailChimpTemplateController
    {
        public async Task<IEnumerable<Template>> GetAllTemplates()
        {
            var templates = await ApiKeyMailChimp.Manager.Templates.GetAllAsync();
            return templates;
        }

        public async Task<Template> GetTemplateById(int templateId)
        {
            var template = await ApiKeyMailChimp.Manager.Templates.GetAsync(templateId);
            return template;
        }

        public async Task<string> GetThumbnailById(int templateId)
        {
            var template = await GetTemplateById(templateId);
            return template.Thumbnail; 
        }

        public async Task<Template> GetLatestTemplate()
        {
            var request = new TemplateRequest
            {
                SortByField = TemplateSortField.DateCreated,
                Count = 1,
            };

            var temporaryTemplate = await ApiKeyMailChimp.Manager.Templates.GetAllAsync(request);
            Template template = new Template();
            foreach (var t in temporaryTemplate)
            {
                template = t;
            }
            return template;
        }
    }
}
