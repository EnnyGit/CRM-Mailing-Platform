using System.Collections.Generic;

public class EmailModel
{
	public int MailId {  get; set;  }

	public UserModel Sender { get; set; }

    public List<ContactModel> Sent { get; set; }

    public List<ContactModel> Read { get; set; }

    public TemplateModel Template { get; set; }

    public string subject { get; set; }
}

