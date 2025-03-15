namespace Discord
{
	public struct ImageHandle
	{
		public ImageType Type;

		public long Id;

		public uint Size;

		public static ImageHandle User(long id)
		{
			return default(ImageHandle);
		}

		public static ImageHandle User(long id, uint size)
		{
			return default(ImageHandle);
		}
	}
}
