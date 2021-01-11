using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM_Model_Library
{
    public interface ILabelData
    {
        Task<List<LabelModel>> GetLabels();
        Task InsertLabel(LabelModel label);
        Task<List<LabelModel>> GetLabel(int id);
        Task<List<ContactModel>> GetContactsWithLabel(int labelId);
        Task DeleteLink(int labelId, int contactId);
        Task InsertLink(int labelId, int contactId);

    }
}