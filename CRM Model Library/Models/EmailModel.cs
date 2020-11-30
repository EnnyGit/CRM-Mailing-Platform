using System.Collections.Generic;

public class EmailModel
{
	public int MailId {  get; set;  }

	public int SenderId { get; set; }

    public int TemplateId { get; set; }

    public string subject { get; set; }
}

