namespace plog.Models
{
	public class Tag
	{
		public string Name { get; private set; }

		public int Hash { get; }

		public UniversalColor Color { get; private set; }

		public Tag(string name)
		{
		}

		public Tag(object obj)
		{
		}

		public override string ToString()
		{
			return null;
		}

		public override bool Equals(object? obj)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
