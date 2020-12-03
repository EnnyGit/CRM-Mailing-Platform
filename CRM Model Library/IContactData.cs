﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRM_Model_Library
{
    public interface IContactData
    {
        Task<List<ContactModel>> GetContacts();
        Task InsertContact(ContactModel contact);
        Task<List<ClientModel>> GetClientsOfContact(int contactId);
        Task<List<ContactModel>> GetSelectContacts(int start,int rows);
        Task<List<ContactModel>> GetContact(int id);
    }
}