using System.Collections.Generic;
using plog.Models;

namespace plog.Helpers
{
	public static class ColorHelper
	{
		private static readonly Dictionary<UniversalColor, (UniversalColor, UniversalColor)> ColorCache;

		public static UniversalColor GetColorForHash(int hash)
		{
			return default(UniversalColor);
		}

		public static UniversalColor Desaturate(this UniversalColor color, float amount = 0.15f)
		{
			return default(UniversalColor);
		}

		public static UniversalColor AdjustVibrance(this UniversalColor color, float amount = 1f)
		{
			return default(UniversalColor);
		}

		private static byte IncreaseChannelVibrance(byte channel, float luminance, float amount)
		{
			return 0;
		}

		public static UniversalColor Lerp(this UniversalColor color, UniversalColor target, float amount)
		{
			return default(UniversalColor);
		}

		public static byte Lerp(this byte value, byte target, float amount)
		{
			return 0;
		}

		public static (UniversalColor, UniversalColor) GetColorPair(UniversalColor color)
		{
			return default((UniversalColor, UniversalColor));
		}
	}
}
