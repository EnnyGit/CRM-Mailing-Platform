using System.Collections.Generic;

public class Email
{
	public int MailId;

	public UserModel Sender;

	public List<Contact> Sent;

	public List<Contact> Read;

	public Template Template;

	public Email(int id,UserModel sender,List<Contact> sent, List<Contact> read,Template temp)
    {
		MailId = id;
		Sender = sender;
		Sent = sent;
		Read = read;
		Template = temp;
    }
}

