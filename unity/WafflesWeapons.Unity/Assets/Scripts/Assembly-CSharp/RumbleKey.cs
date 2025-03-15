public class RumbleKey
{
	public string name { get; private set; }

	public int hashKey { get; private set; }

	public RumbleKey(string name)
	{
	}

	public override string ToString()
	{
		return null;
	}

	public override bool Equals(object obj)
	{
		return false;
	}

	public override int GetHashCode()
	{
		return 0;
	}
}
