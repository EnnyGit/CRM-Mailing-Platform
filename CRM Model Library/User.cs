public class User
{
	public int UserId;
	public string FirstName;

	public string LastName;

	public string UserName;

	protected string PassWord;

	public string EmailAddress;

	public User(int id,string fname,string lname, string uname,string pw,string eaddress)
    {
		UserId = id;
		FirstName = fname;
		LastName = lname;
		UserName = uname;
		PassWord = pw;
		EmailAddress = eaddress;
    }
}

