public class ContactModel
{
    public int ContactId { get; set; }

    public string EmailAddress { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string SearchTerm()
    {
        return EmailAddress + FirstName + LastName;
    }

    public string GetInfo(bool withemail = false)
    {
        if (withemail)
        {
            return FirstName + " " + LastName + ", " + EmailAddress;
        }
        else
        {
            return FirstName + " " + LastName;
        }
    }
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