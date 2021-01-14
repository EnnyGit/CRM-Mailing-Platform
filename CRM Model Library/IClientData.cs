using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM_Model_Library
{
    public interface IClientData
    {
        Task<List<ClientModel>> GetClients();

        Task InsertClient(ClientModel client);

        Task<List<ContactModel>> GetContactsOfClient(int clientId);

        Task InsertLink(int contactId, int clientId);

        Task DeleteLink(int contactId, int clientId);

        Task<List<ClientModel>> GetClient(int id);
    }
}