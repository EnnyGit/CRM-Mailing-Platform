public class LabelModel
{
	public int LabelId { get; set; }

	public string LabelName { get; set; }
    public override bool Equals(object obj)
    {
        if ((obj == null) || !this.GetType().Equals(obj.GetType()))
        {
            return false;
        }
        else
        {
            LabelModel c = (LabelModel)obj;
            return this.LabelId == c.LabelId;
        }
    }
}




