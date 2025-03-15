using System.Collections.Generic;
using UnityEngine;

namespace NewBlood.IK
{
	public abstract class Solver3D : MonoBehaviour
	{
		[SerializeField]
		private bool m_ConstrainRotation;

		[SerializeField]
		private bool m_SolveFromDefaultPose;

		[Range(0f, 1f)]
		[SerializeField]
		private float m_Weight;

		private List<Vector3> m_TargetPositions;

		public int chainCount => 0;

		public bool constrainRotation
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool solveFromDefaultPose
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool isValid => false;

		public bool allChainsHaveTargets => false;

		public float weight
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public void UpdateIK(float globalWeight)
		{
		}

		public void UpdateIK(List<Vector3> positions, float globalWeight)
		{
		}

		public void Initialize()
		{
		}

		public abstract IKChain3D GetChain(int index);

		protected abstract int GetChainCount();

		protected abstract void DoUpdateIK(List<Vector3> effectorPositions);

		protected virtual bool DoValidate()
		{
			return false;
		}

		protected virtual void DoInitialize()
		{
		}

		protected virtual void DoPrepare()
		{
		}

		protected virtual Transform GetRootTransform()
		{
			return null;
		}

		protected virtual void OnValidate()
		{
		}

		private void Prepare()
		{
		}

		private void PrepareEffectorPositions()
		{
		}

		private void StoreLocalRotations()
		{
		}

		private void BlendFKToIK(float finalWeight)
		{
		}
	}
}
