using System.Net;

public class Contact
{
	private int contactId;
	public int ContactId { get { return contactId; } }

	public int[] Labels;

	public string EmailAddress;

	public string FirstName;

	public string LastName;

	public int[] Clients;

	private Label label;

	private Client client;

}

