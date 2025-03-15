using UnityEngine;

namespace NewBlood.Interop
{
	public struct SharedRendererData
	{
		public TransformInfo m_TransformInfo;

		public StaticBatchInfo m_StaticBatchInfo;

		public GlobalLayeringData m_GlobalLayeringData;

		public Vector4 m_LightmapST_0;

		public Vector4 m_LightmapST_1;

		public LightmapIndices m_LightmapIndex;

		private uint _bitfield1;

		public uint m_RenderingLayerMask;

		public int m_RendererPriority;
	}
}
