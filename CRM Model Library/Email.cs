using System.Collections.Generic;

public class Email
{
	public int MailId { get; set; }

	public User Sender { get; set; }

	public List<Contact> Sent { get; set; }

	public List<Contact> Read = new List<Contact>();

	public Template Template { get; set; }

	
}

