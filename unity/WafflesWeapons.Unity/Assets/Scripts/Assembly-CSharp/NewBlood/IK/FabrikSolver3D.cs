using System.Collections.Generic;
using UnityEngine;

namespace NewBlood.IK
{
	public sealed class FabrikSolver3D : Solver3D
	{
		public const float MinTolerance = 0.001f;

		public const int MinIterations = 1;

		[SerializeField]
		private IKChain3D m_Chain;

		[SerializeField]
		[Range(1f, 50f)]
		private int m_Iterations;

		[SerializeField]
		[Range(0.001f, 0.1f)]
		private float m_Tolerance;

		private Vector3[] m_Positions;

		public int iterations
		{
			get
			{
				return 0;
			}
			set
			{
			}
		}

		public float tolerance
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public override IKChain3D GetChain(int index)
		{
			return null;
		}

		protected override int GetChainCount()
		{
			return 0;
		}

		protected override void DoPrepare()
		{
		}

		protected override void DoUpdateIK(List<Vector3> effectorPositions)
		{
		}

		private void Forward(Vector3 targetPosition, float[] lengths, Vector3[] positions)
		{
		}

		private void Backward(Vector3 originPosition, float[] lengths, Vector3[] positions)
		{
		}
	}
}
