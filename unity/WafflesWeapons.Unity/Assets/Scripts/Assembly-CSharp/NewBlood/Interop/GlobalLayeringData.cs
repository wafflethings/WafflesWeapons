using System.Runtime.InteropServices;

namespace NewBlood.Interop
{
	[StructLayout(LayoutKind.Explicit)]
	public struct GlobalLayeringData
	{
		public struct SortingGroup
		{
			private uint _bitfield;

			public uint order
			{
				readonly get
				{
					return 0u;
				}
				set
				{
				}
			}

			public uint id
			{
				readonly get
				{
					return 0u;
				}
				set
				{
				}
			}
		}

		[FieldOffset(0)]
		public uint layerAndOrder;

		[FieldOffset(4)]
		public SortingGroup sortingGroup;

		[FieldOffset(4)]
		public uint sortingGroupAll;
	}
}
