using MailChimp.Net.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM_Model_Library
{
    public interface IMailChimpTemplateController
    {
        Task<IEnumerable<Template>> GetAllTemplates();
        Task<string> GetThumbnailById(int templateId);
        Task<Template> GetTemplateById(int templateId);
        Task<Template> GetLatestTemplate();
    }
}