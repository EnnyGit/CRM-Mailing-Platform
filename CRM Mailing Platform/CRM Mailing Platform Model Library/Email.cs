public class Email
{
	private int mailId;
	public int MailId { get { return mailId; } }

	public User Sender;

	public int[] ReceivedNotRead;

	public int[] ReceivedRead;

	public Template Template;

}

