using System.Collections.Generic;

public class Contact
{
	public int ContactId;

	public List<Label> Labels;

	public string EmailAddress;

	public string FirstName;

	public string LastName;

	public List<Client> Clients;


	public Contact(int id, List<Label> labels,string eaddress,string fname,string lname,List<Client> clients)
    {
		ContactId = id;
		Labels = labels;
		EmailAddress = eaddress;
		FirstName = fname;
		LastName = lname;
		Clients = clients;
    }


}
