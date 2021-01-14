using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM_Model_Library
{
    public interface ILableData
    {
        Task<List<LableModel>> GetLabels();
    }
}