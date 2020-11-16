using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM_Model_Library
{
    public interface IClientData
    {
        Task<List<ClientModel>> GetClients();
        Task InsertClient(ClientModel client);
    }
}