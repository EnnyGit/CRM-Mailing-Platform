public class ContactModel
{
    public int ContactId { get; set; }

    public string EmailAddress { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public override bool Equals(object obj)
    {
        if ((obj == null) || !this.GetType().Equals(obj.GetType()))
        {
            return false;
        }
        else
        {
            ContactModel c = (ContactModel)obj;
            return this.ContactId == c.ContactId;
        }
    }
}