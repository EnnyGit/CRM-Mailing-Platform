using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRM_Project.Pages
{
    public class ContactListBase : ComponentBase
    {
        public IEnumerable<Contact> Contacts { get; set; }
        private List<Contact> LoadContacts()
        {
            Contact c1 = new Contact
            {
                ContactId = 1,
                FirstName = "Rim",
                LastName = "Ranshuijsen",
                EmailAddress = "rim@renvl.com",
                Clients = new List<Client> { },
                Labels = new List<Label> { }
            };
            Contact c2 = new Contact
            {
                ContactId = 2,
                FirstName = "Jonas",
                LastName = "de Boer",
                EmailAddress = "jonasdeboer02@gmail.com",
                Clients = new List<Client> { },
                Labels = new List<Label> { }
            };
            Contact c3 = new Contact
            {
                ContactId = 3,
                FirstName = "Dennis",
                LastName = "Futselaar",
                EmailAddress = "dennisfuts1998@gmail.com",
                Clients = new List<Client> { },
                Labels = new List<Label> { }
            };
            return new List<Contact> { c1, c2, c3 };
        }
    }
}
