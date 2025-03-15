using UnityEngine;

namespace DitzelGames.FastIK
{
	[DefaultExecutionOrder(int.MaxValue)]
	public class FastIKFabric : MonoBehaviour
	{
		public int chainLength;

		public Transform target;

		public Transform pole;

		[Header("Solver Parameters")]
		public int iterations;

		public float delta;

		[Range(0f, 1f)]
		public float snapBackStrength;

		protected float[] bonesLength;

		protected float completeLength;

		protected Transform[] bones;

		protected Vector3[] positions;

		protected Vector3[] startDirectionSucc;

		protected Quaternion[] startRotationBone;

		protected Quaternion startRotationTarget;

		protected Transform root;

		private void Awake()
		{
		}

		private void Init()
		{
		}

		private void LateUpdate()
		{
		}

		private void ResolveIK()
		{
		}

		private Vector3 GetPositionRootSpace(Transform current)
		{
			return default(Vector3);
		}

		private void SetPositionRootSpace(Transform current, Vector3 position)
		{
		}

		private Quaternion GetRotationRootSpace(Transform current)
		{
			return default(Quaternion);
		}

		private void SetRotationRootSpace(Transform current, Quaternion rotation)
		{
		}

		private void OnDrawGizmos()
		{
		}
	}
}
