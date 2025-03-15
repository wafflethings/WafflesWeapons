using System.Runtime.InteropServices;

namespace NewBlood.Interop
{
	public struct BaseRenderer
	{
		public unsafe void** __vftable;

		public SharedRendererData m_RendererData;

		public unsafe void* m_RendererProperties;

		[MarshalAs(UnmanagedType.U1)]
		public bool m_ForceRenderingOff;
	}
}
