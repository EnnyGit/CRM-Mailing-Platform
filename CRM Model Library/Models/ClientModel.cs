public class ClientModel
{
    public int ClientId { get; set; }

    public string Name { get; set; }

    public string SearchTerm()

    {
        return ClientId + Name;
    }

    public override bool Equals(object obj)
    {
        if ((obj == null) || !this.GetType().Equals(obj.GetType()))
        {
            return false;
        }
        else
        {
            ClientModel c = (ClientModel)obj;
            return this.ClientId == c.ClientId;
        }
    }
}