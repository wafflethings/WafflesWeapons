using System.Collections.Generic;
using UnityEngine;

namespace NewBlood.IK
{
	public sealed class IKManager3D : MonoBehaviour
	{
		[SerializeField]
		private List<Solver3D> m_Solvers;

		[Range(0f, 1f)]
		[SerializeField]
		private float m_Weight;

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

		public List<Solver3D> solvers => null;

		public void AddSolver(Solver3D solver)
		{
		}

		public void RemoveSolver(Solver3D solver)
		{
		}

		public void UpdateManager()
		{
		}

		private void LateUpdate()
		{
		}

		private void FindChildSolvers()
		{
		}
	}
}
