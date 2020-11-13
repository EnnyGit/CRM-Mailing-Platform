using System.Collections.Generic;

public class Client
{
	public int ClientId;

	public List<Contact> Contacts;

	public string Name;

	public Client(int id,List<Contact> contacts,string name)
    {
		ClientId = id;
		Contacts = contacts;
		Name = name;
    }

}

