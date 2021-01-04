using System.Collections.Generic;

public class EmailModel
{
	public int MailId {  get; set;  }

	public int SenderId { get; set; }

    public int TemplateId { get; set; }

    public string subject { get; set; }

    public override bool Equals(object obj)
    {
        if ((obj == null) || !this.GetType().Equals(obj.GetType()))
        {
            return false;
        }
        else
        {
            EmailModel e = (EmailModel)obj;
            return this.MailId == e.MailId;
        }
    }
}

