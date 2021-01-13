using MailChimp.Net.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM_Model_Library
{
    public interface IMailChimpListController
    {
        Task<IEnumerable<List>> GetAllLists();
        Task<List> GetDetailOfList(string id);
        Task AddMemberToList();
        Task AddMemberToList2();
    }
}