using System.Collections.Generic;

public class Email
{
	public int MailId;

	public User Sender;

	public List<Contact> Sent;

	public List<Contact> Read;

	public Template Template;

	public Email(int id,User sender,List<Contact> sent, List<Contact> read,Template temp)
    {
		MailId = id;
		Sender = sender;
		Sent = sent;
		Read = read;
		Template = temp;
    }
}
