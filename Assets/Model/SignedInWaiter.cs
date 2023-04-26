using System;
public class SignedInWaiter
{
	public string username { get; set; }

    public string password { get; set; }

    public string firstName { get; set; }

    public string lastName { get; set; }

    public SignedInWaiter(string un, string pw, string first, string last)
    {
        username = un;
        password = pw;
        firstName = first;
        lastName = last;
    }

}

