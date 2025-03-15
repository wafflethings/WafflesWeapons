using UnityEngine;

namespace NewBlood.IK
{
	internal static class IKUtility
	{
		public static bool IsDescendantOf(Transform transform, Transform ancestor)
		{
			return false;
		}

		public static bool IsDescendantOf(Transform transform, Transform ancestor, int ancestorCount)
		{
			return false;
		}

		public static bool AncestorCountAtLeast(Transform transform, int count)
		{
			return false;
		}

		public static int GetAncestorCount(Transform transform)
		{
			return 0;
		}

		public static int GetMaxChainCount(IKChain3D chain)
		{
			return 0;
		}
	}
}
