using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM_Model_Library
{
    public interface ILabelData
    {
        Task<List<LabelModel>> GetLables();
        Task InsertLabel(LabelModel lable);
    }
}