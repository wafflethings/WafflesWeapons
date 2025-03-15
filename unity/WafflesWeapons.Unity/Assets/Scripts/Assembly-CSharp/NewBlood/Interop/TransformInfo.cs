using UnityEngine;

namespace NewBlood.Interop
{
	public struct TransformInfo
	{
		public Matrix4x4 worldMatrix;

		public Matrix4x4 prevWorldMatrix;

		public Bounds worldAABB;

		public Bounds localAABB;

		public int motionVectorFrameIndex;

		public TransformType transformType;

		public ushort lateLatchIndex;
	}
}
