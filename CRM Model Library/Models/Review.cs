public class Review
{
	public int ReviewId;

	public bool Read;

	public string Content;

	public Contact Contact;

	public Review(int id, bool read, string content, Contact contact)
    {
        ReviewId = id;
		Read = read;
        Content = content;
        Contact = contact;
    }
}

