using System.Collections.Generic;

public class Contact
{
	public int ContactId { get; set; }

	public List<Label> Labels { get; set; }

	public string EmailAddress { get; set; }

	public string FirstName { get; set; }

	public string LastName { get; set; }

	public List<Client> Clients { get; set; }


	


}

