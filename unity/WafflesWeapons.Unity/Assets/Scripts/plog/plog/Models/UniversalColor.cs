namespace plog.Models
{
	public struct UniversalColor
	{
		public readonly byte Red;

		public readonly byte Green;

		public readonly byte Blue;

		public UniversalColor(byte red, byte green, byte blue)
		{
			Red = 0;
			Green = 0;
			Blue = 0;
		}

		public UniversalColor(int red, int green, int blue)
		{
			Red = 0;
			Green = 0;
			Blue = 0;
		}

		public UniversalColor(float red, float green, float blue)
		{
			Red = 0;
			Green = 0;
			Blue = 0;
		}

		public UniversalColor CopyWith(byte? red = null, byte? green = null, byte? blue = null)
		{
			return default(UniversalColor);
		}
	}
}
