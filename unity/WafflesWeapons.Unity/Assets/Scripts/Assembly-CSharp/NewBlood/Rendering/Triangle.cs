using System.Runtime.CompilerServices;

namespace NewBlood.Rendering
{
	public struct Triangle<TIndex> where TIndex : unmanaged
	{
		public TIndex Index0;

		public TIndex Index1;

		public TIndex Index2;

		public TIndex this[int index]
		{
			get
			{
				return default(TIndex);
			}
			set
			{
			}
		}

		public Triangle(TIndex index0, TIndex index1, TIndex index2)
		{
			Index0 = default(TIndex);
			Index1 = default(TIndex);
			Index2 = default(TIndex);
		}

		private static TIndex ThrowIndexOutOfRangeException()
		{
			return default(TIndex);
		}
	}
}
