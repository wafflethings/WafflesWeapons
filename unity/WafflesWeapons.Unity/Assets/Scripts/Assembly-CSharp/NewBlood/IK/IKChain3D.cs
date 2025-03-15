using System;
using UnityEngine;

namespace NewBlood.IK
{
	[Serializable]
	public sealed class IKChain3D
	{
		[SerializeField]
		private Transform m_EffectorTransform;

		[SerializeField]
		private Transform m_TargetTransform;

		[SerializeField]
		private int m_TransformCount;

		[SerializeField]
		private Transform[] m_Transforms;

		[SerializeField]
		private Quaternion[] m_DefaultLocalRotations;

		[SerializeField]
		private Quaternion[] m_StoredLocalRotations;

		private float[] m_Lengths;

		public bool isValid => false;

		public int transformCount => 0;

		public Transform effector
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Transform target
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Transform[] transforms => null;

		public Transform rootTransform => null;

		public float[] lengths => null;

		public void Initialize()
		{
		}

		public void RestoreDefaultPose(bool targetRotationIsConstrained)
		{
		}

		public void StoreLocalRotations()
		{
		}

		public void BlendFKToIK(float finalWeight, bool targetRotationIsConstrained)
		{
		}

		private void PrepareLengths()
		{
		}
	}
}
