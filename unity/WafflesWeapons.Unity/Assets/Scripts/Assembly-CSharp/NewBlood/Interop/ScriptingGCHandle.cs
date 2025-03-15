using System.Runtime.InteropServices;

namespace NewBlood.Interop
{
	public struct ScriptingGCHandle
	{
		public GCHandle m_Handle;

		public ScriptingGCHandleWeakness m_Weakness;

		public unsafe void* m_Object;
	}
}
