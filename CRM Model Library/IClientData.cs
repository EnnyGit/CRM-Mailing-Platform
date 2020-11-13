using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM_Model_Library
{
    interface IClientData
    {
        Task<List<ClientModel>> GetClients();
        Task InsertPerson(ClientModel person);
    }
}