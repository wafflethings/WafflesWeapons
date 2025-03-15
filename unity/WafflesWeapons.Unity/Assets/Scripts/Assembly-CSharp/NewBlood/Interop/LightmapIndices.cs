using System.Runtime.InteropServices;

namespace NewBlood.Interop
{
	[StructLayout(LayoutKind.Explicit)]
	public struct LightmapIndices
	{
		[FieldOffset(0)]
		public uint combined;

		[FieldOffset(0)]
		public unsafe fixed ushort indices[2];
	}
}
